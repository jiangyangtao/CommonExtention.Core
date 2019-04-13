# Common 常用组件

## 异步日志

> 命名空间：`using CommonExtention.Core.Common;`  
> 日志不会阻塞线程。  
> 日志路径：当前项目根目录的 `log` 文件夹下。  
> 异常日志：error.txt，信息日志：information.txt，请求日志：request.txt。

- 记录异常

``` csharp
AsyncLogger.LogException(Exception exception)
```

- 记录关键信息

``` csharp
AsyncLogger.LogInformation(string information)
```

- 记录 Mvc 请求信息

``` csharp
AsyncLogger.LogMvcRequest(MvcRequest model)
```

<br/>
<br/>

## Json 通用返回格式

> 命名空间：`using CommonExtention.Core.Common;`

``` json
{
  "code" : 0,
  "data" : {},
  "count" : 0,
  "message" : "Success"
}
```

- 规范 Json 返回数据的格式。格式中有四个属性，分别是Code、Data、Count、Message。
- Code 为 0 时，表示请求成功，其它数据表示失败。
- Data 表示返回的数据。
- Count 表示返回的数据量，可以用于分页的数据量。
- Message 表示返回的消息，在请求/业务逻辑失败时，返回错误的消息。
- 在控制器中使用时，Mvc 继承 `BasicsController`。
- 单独使用时，引入 `using CommonExtention.Core.HttpResponseFormat;` 命名空间，使用静态类 `JsonResultFormat`。

``` csharp

// 返回成功，用于增、删、改等操作成功时的返回。
ResponseSuccess();


// 返回成功，用于返回单个对象/单条数据。
ResponseSuccess<T>(T data, int count = 1);



// 返回成功，用于返回 List 数据。
ResponseSuccess<T>(List<T> list, int count = 0);



// 返回成功，用于增、删、改等操作成功时的返回。
ResponseSuccess(DataTable dataTable, int count = 0);


// 返回失败，用于返回失败。
ResponseFail(int code = -1, string message = "Unknown error");

```

<br/>
<br/>


## Json 通用网格返回格式

> 命名空间：`using CommonExtention.Core.Common;`  
> 与 `Json 通用返回格式`原理、使用一样，通用网格的定位用于后台、管理系统一类的项目。

``` json
{
  "code" : 0,
  "rows" : {},
  "total" : 0,
  "message" : "Success"
}
```

- 规范 Json 返回数据的格式。格式中有四个属性，分别是Code、Rows、Total、Message。
- Code 为 0 时，表示请求成功，其它数据表示失败。
- Rows 表示返回的数据。
- Total 表示返回的数据量，可以用于分页的数据量。
- Message 表示返回的消息，在请求/业务逻辑失败时，返回错误的消息。
- 在控制器中使用时，Mvc 继承 `BasicsController`。
- 单独使用时，引入 `using CommonExtention.Core.HttpResponseFormat;` 命名空间，使用静态类 `JsonResultFormat`。

``` csharp

// 返回成功，用于增、删、改等操作成功时的返回。
ResponseGridResult();


// 返回成功，用于返回单个对象/单条数据。
ResponseGridResult<T>(T data, int count = 1);


// 返回成功，用于返回 List 数据。
ResponseGridResult<T>(List<T> list, int count = 0);


// 返回成功，用于返回 DataTable 数据。
ResponseGridResult(DataTable dataTable, int count = 0);


// 返回失败，用于返回失败。
ResponseGridResult(int code = -1, string message = "Unknown error");

```

<br/>
<br/>

## 发送邮件

> 对 `SmtpClient` 和 `MailMessage` 两个类进行的封装。  
> 命名空间：`using CommonExtention.Core.Common;`、`using CommonExtention.Core.Models;`  
> 使用时需要配置 `EmailServiceConfig` 和 `EmailContent` 两个类。

- `EmailContent` 类说明：  

| 属性           | 类型                   |  说明        |  是否必须  |  默认值  |
| ----------    | -----                  | ------       | --------- | -------- |
| Title         | string                 |  标题、主题   | 是        |          |
| Body          | string                 |  邮件主体     | 是        |          |
| IsHtmlContent | bool                   |  html 内容    | 否        |  false  |
| ReplyAddress  | MailAddress            |  邮件回复地址 | 是        |          |
| Priority      | MailPriority           |  邮件优先级   | 是        | MailPriority.Normal |
| Attachment    | `Collection<Attachment>` |  附件         | 否        |          |

<br/>

- `EmailServiceConfig` 类说明：

| 属性                  | 类型                |  说明                          |  是否必须  |  默认值  |
| ----------            | -----              | ------                        | --------- | -------- |
| Host                  | string             |  Smtp 服务器地址               | 是        |          |
| Port                  | int                |  Smtp 服务器的端口             | 是        |   25     |
| EnableSsl             | bool               |  Smtp 服务器是否启用 SSL 加密   | 否        |  true    |
| EmailAddress          | string             |  邮箱账号                      | 是        |          |
| Password              | string             |  密码                          | 是        |         |
| UseDefaultCredentials | bool               |  系统凭据是否随请求发送         | 否        |  false   |
| DeliveryMethod        | SmtpDeliveryMethod |  Smtp 传输方式                 | 否        | SmtpDeliveryMethod.Network |

<br/>

- 初始化

``` csharp

var email = new Email();

var email = new Email(EmailContent emailContent);

var email = new Email(EmailServiceConfig serviceConfig);

var email = new Email(EmailServiceConfig serviceConfig, EmailContent emailContent);

// 也可以在初始化后配置
email.EmailContent = new EmailContent();
email.ServiceConfig = new EmailServiceConfig();


// 手动释放资源
email.Dispose();


// 使用 using 方法自动释放资源
using(var email = new Email())
{

}

```

<br/>

- 发送

``` csharp

// 接收、抄送、密送
email.Receivers.Add(new MailAddress()); // 接收
email.CarbonCopy.Add(new MailAddress()); // 抄送
email.BlindCarbonCopy.Add(new MailAddress()); // 密送
email.Send();


// 发送给单个地址
email.Send(MailAddress mailAddress);

// 发送给多个地址
email.Send(Collection<MailAddress> mails);

```

<br/>

- 异步发送

> 发送方式与同步相同。此方法不会阻止调用线程，并允许调用方将对象传递给操作完成时调用的方法。  
> .Net Framework 4.0 调用异步不需要 async/await。

 ``` csharp

// 接收、抄送、密送
email.Receivers.Add(new MailAddress()); // 接收
email.CarbonCopy.Add(new MailAddress()); // 抄送
email.BlindCarbonCopy.Add(new MailAddress()); // 密送
async email.SendAsync();


// 发送给单个地址
async email.SendAsync(MailAddress mailAddress);

// 发送给多个地址
async email.SendAsync(Collection<MailAddress> mails);

 ```

<br/>
<br/>

## Excel 操作

> 封装对 Excel 导入、导出的操作。  
> 命名空间：`using CommonExtention.Common;` 、`using CommonExtention.Extensions;`

### 导入

- 通过 FormData 上传，读取单个文件的指定的 Sheet

``` csharp

// 通过实例化 Excel 类使用
var excel = new Excel();
excel.ReadHttpPostedFileToDataTable(httpPostedFile, sheetName, firstRowIsColumnName, addEmptyRow);

// 通过 Rqequest.Files 的扩展使用
Request.Files[0].ReadToDataTable(sheetName, firstRowIsColumnName, addEmptyRow);

```

- 通过 FormData 上传，异步读取单个文件的指定的 Sheet

``` csharp

// 通过实例化 Excel 类使用
var excel = new Excel();
async excel.ReadHttpPostedFileToDataTableAsync(httpPostedFile, sheetName, firstRowIsColumnName, addEmptyRow);

// 通过 Rqequest.Files 的扩展使用
async Request.Files[0].ReadToDataTableAsync(sheetName, firstRowIsColumnName, addEmptyRow);

```

- 通过 FormData 上传，读取单个文件的所有的 Sheet

``` csharp

// 通过实例化 Excel 类
var excel = new Excel();
excel.ReadHttpPostedFileToTables(httpPostedFile, sheetName, firstRowIsColumnName, addEmptyRow);

// 通过 Rqequest.Files 的扩展使用
Request.Files[0].ReadToTables(firstRowIsColumnName, addEmptyRow);

```

- 通过 FormData 上传，异步读取单个文件的所有的 Sheet

``` csharp

// 通过实例化 Excel 类
var excel = new Excel();
async excel.ReadHttpPostedFileToTablesAsync(httpPostedFile, sheetName, firstRowIsColumnName, addEmptyRow);

// 通过 Rqequest.Files 的扩展使用
async Request.Files[0].ReadToTablesAsync(firstRowIsColumnName, addEmptyRow);

```

- 通过 FormData 上传，读取所有文件的所有的 Sheet

``` csharp

// 通过实例化 Excel 类
var excel = new Excel();
excel.ReadHttpFileCollectionToTableCollection(httpPostedFile, sheetName, firstRowIsColumnName, addEmptyRow);

// 通过 Rqequest.Files 的扩展使用
Request.Files.ReadToTableCollection();

```

- 通过指定文件的路径，读取单个文件的指定的 Sheet

``` csharp

var excel = new Excel();
excel.ReadExcelToDataTable(filePath, sheetName, firstRowIsColumnName, addEmptyRow);

```

- 通过指定文件的路径，异步读取单个文件的指定的 Sheet

``` csharp

var excel = new Excel();
async excel.ReadExcelToDataTableAsync(filePath, sheetName, firstRowIsColumnName, addEmptyRow);

```

- 通过指定文件的路径，读取单个文件的所有的 Sheet

``` csharp

var excel = new Excel();
excel.ReadExcelToTables(filePath, firstRowIsColumnName, addEmptyRow);

```

- 通过指定文件的路径，异步读取单个文件的所有的 Sheet

``` csharp

var excel = new Excel();
async excel.ReadExcelToTablesAsync(filePath, firstRowIsColumnName, addEmptyRow);

```

- 通过 Stream 流，读取单个文件的指定的 Sheet

``` csharp

// 通过实例化 Excel 类
var excel = new Excel();
excel.ReadStreamToDataTable(stream, sheetName, firstRowIsColumnName, addEmptyRow);

// 通过 Stream 的扩展使用
stream.ReadStreamToDataTable(sheetName, firstRowIsColumnName, addEmptyRow);

```

- 通过 Stream 流，读取单个文件的所有的 Sheet

``` csharp

// 通过实例化 Excel 类
var excel = new Excel();
excel.ReadStreamToTables(stream, firstRowIsColumnName, addEmptyRow);

// 通过 Stream 的扩展使用
stream.ReadToDataTable(firstRowIsColumnName, addEmptyRow);

```

- 通过 Stream 流，异步读取单个文件的指定的 Sheet

``` csharp

// 通过实例化 Excel 类
var excel = new Excel();
async excel.ReadStreamToDataTableAsync(stream, sheetName, firstRowIsColumnName, addEmptyRow);

// 通过 Stream 的扩展使用
async stream.ReadToDataTableAsync(sheetName, firstRowIsColumnName, addEmptyRow);

```

- 通过 Stream 流，异步读取单个文件的所有的 Sheet

``` csharp

// 通过实例化 Excel 类
var excel = new Excel();
async excel.ReadStreamToTablesAsync(stream, firstRowIsColumnName, addEmptyRow);

// 通过 Stream 的扩展使用
async stream.ReadToTablesAsync(firstRowIsColumnName, addEmptyRow);

```

### 导出

- DataTable 导出

``` csharp

var table = new DataTable();

// 通过实例化 Excel 类使用
var excel = new Excel();
var memoryStream = excel.WriteToMemoryStream(table,(worksheet, columns, rows) =>
{
   // TO DO
}, "Sheet");


// 通过 DataTable 的扩展使用
var memoryStream = table.WriteToMemoryStream((worksheet, columns, rows) =>
{
    // 表头
    for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
    {
        var column = columns[columnIndex];
        worksheet.Cells[1, columnIndex + 1].Value = column.ColumnName;
        Excel.DrawBorder(worksheet.Cells[1, columnIndex + 1].Style);
    }

    // 数据行
    for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
    {
        var row = rows[rowIndex];
        for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
        {
            var column = columns[columnIndex];
            var cell = worksheet.Cells[rowIndex + 2, columnIndex + 1];
            cell.Value = row[column.ColumnName];
            Excel.DrawBorder(cell.Style);
        }
    }
}, "Sheet");

return File(memoryStream.GetBuffer(), Excel.ContentType, "Excel.xlsx");

```

- DataTable 异步导出

``` csharp

var table = new DataTable();

// 通过实例化 Excel 类使用
var excel = new Excel();
var memoryStream = async excel.WriteToMemoryStreamAsync(table,(worksheet, columns, rows) =>
{
   // TO DO
}, "Sheet");


// 通过 DataTable 的扩展使用
var memoryStream = async table.WriteToMemoryStreamAsync((worksheet, columns, rows) =>
{
    // 表头
    for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
    {
        var column = columns[columnIndex];
        worksheet.Cells[1, columnIndex + 1].Value = column.ColumnName;
        Excel.DrawBorder(worksheet.Cells[1, columnIndex + 1].Style);
    }

    // 数据行
    for (int rowIndex = 0; rowIndex < rows.Count; rowIndex++)
    {
        var row = rows[rowIndex];
        for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
        {
            var column = columns[columnIndex];
            var cell = worksheet.Cells[rowIndex + 2, columnIndex + 1];
            cell.Value = row[column.ColumnName];
            Excel.DrawBorder(cell.Style);
        }
    }
}, "Sheet");

return File(memoryStream.GetBuffer(), Excel.ContentType, "Excel.xlsx");

```

- List 导出

``` csharp

var list = new List<T>();

// 通过实例化 Excel 类使用
var excel = new Excel();
var memoryStream = excel.WriteToMemoryStream(list,(worksheet, columns, rows) =>
{
   // TO DO
}, "Sheet");


// 通过 List 的扩展使用
var memoryStream = list.WriteToMemoryStream((worksheet, properties)=>{
  propertes.ForEach((column, columnIndex) => {
      worksheet.Cells[1, columnIndex + 1].Value = column.Name;
      Excel.DrawBorder(worksheet.Cells[1, columnIndex + 1].Style);
  });

  list.ForEach((row, rowIndex) => {
      propertes.ForEach((column, columnIndex) => {
          var value = column.GetValue(row, null);
          worksheet.Cells[rowIndex + 2, columnIndex + 1].Value = value;
          Excel.DrawBorder(worksheet.Cells[rowIndex + 2, columnIndex + 1].Style);
      });
  });
}, "Sheet");

return File(memoryStream.GetBuffer(), Excel.ContentType, "Excel.xlsx");

```

- List 异步导出

``` csharp

var list = new List<T>();

// 通过实例化 Excel 类使用
var excel = new Excel();
var memoryStream = async excel.WriteToMemoryStreamAsync(list, (worksheet, columns, rows) =>
{
   // TO DO
}, "Sheet");


// 通过 List 的扩展使用
var memoryStream = async list.WriteToMemoryStreamAsync((worksheet, properties)=>{
  propertes.ForEach((column, columnIndex) => {
      worksheet.Cells[1, columnIndex + 1].Value = column.Name;
      Excel.DrawBorder(worksheet.Cells[1, columnIndex + 1].Style);
  });

  list.ForEach((row, rowIndex) => {
      propertes.ForEach((column, columnIndex) => {
          var value = column.GetValue(row, null);
          worksheet.Cells[rowIndex + 2, columnIndex + 1].Value = value;
          Excel.DrawBorder(worksheet.Cells[rowIndex + 2, columnIndex + 1].Style);
      });
  });
}, "Sheet");

return File(memoryStream.GetBuffer(), Excel.ContentType, "Excel.xlsx");

```

<br/>
<br/>

## Mvc 返回约定

> 命名空间：`using CommonExtention.Core.Common;`

- Json 全小写约定

``` csharp

services.AddMvc(config =>
{

}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
{
    // 全小写约定设置
    options.SerializerSettings.ContractResolver = new LowercaseContractResolver();
});

```

- Json 全大写约定

``` csharp

services.AddMvc(config =>
{

}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options =>
{
    // 全大写约定设置
    options.SerializerSettings.ContractResolver = new UppercaseContractResolver();
});

```


<br/>
<br/>

## 身份证号码的验证

> 命名空间：`using CommonExtention.Core.Common;`

- 通过实例化 IdentityCardNumber 使用

``` csharp

var identityCardNumber = new IdentityCardNumber(value);

// 是否为身份证号码。如果身份证验证通过，则为 true; 否则为 false
identityCardNumber.IsIdentityNumber

// 出生日期。如果身份证验证通过，则为 身份证号码上的出生日期; 否则为 null
identityCardNumber.BirthDate

// 年龄。如果身份证验证通过，则为 身份证号码公民的当前周岁; 否则为 -1
AidentityCardNumber.ge

// 性别。如果身份证验证通过，则返回 男 / 女; 否则返回 空字符串("")
identityCardNumber.GenderText

// 性别代码。如果身份证验证通过，则为 0：女 / 1：男; 否则为 -1
identityCardNumber.GenderCode

```

- 通过 String 的扩展使用

``` csharp

// 是否为身份证号码，true：是，false：否
value.IsChinaIdentityNumber();

// 获取身份证号码字符串的出生日期
value.GetDateOfBirthOfChinaIDNumber();


// 获取身份证号码字符串的当前年龄
value.GetAgeOfChinaIDNumber();

// 获取身份证号码字符串的性别的文字，男 / 女
value.GetGenderTextOfChinaIDNumber();


// 获取身份证号码字符串的性别的数字，0 - 女，1 - 男
value.GetGenderCodeOfChinaIDNumber();

```

<br/>
<br/>

## 图片验证码

> 命名空间：`using CommonExtention.Core.Common;`

``` csharp

var imageVerificationCode = new ImageVerificationCode(number);

// 验证码
imageVerificationCode.Code

// 生成图片验证码
imageVerificationCode.CreateImage(width, height, fontSize, fontFamily, backgroundColor, lineNumber, lineColor, drawPoint, dotNumber);

```

<br/>
<br/>

## 生成密码

> 命名空间：`using CommonExtention.Core.Common;`

``` csharp

var passwordGenerator = new PasswordGenerator();

// 生成密码
passwordGenerator.NewPassword(length, containsAtSymbol, containsSymbol);

```

## 连续的 Guid

> 命名空间：`using CommonExtention.Core.Common;`  
> 代码出自: <a href="https://www.cnblogs.com/CameronWu/p/guids-as-fast-primary-keys-under-multiple-database.html" target="_blank">使用有序GUID：提升其在各数据库中作为主键时的性能</a>  
> 此代码尚未测试，谨慎使用。

``` csharp

// Sequential As String
SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAsString);

// Sequential As Binary
SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAsBinary);

// Sequential At End
SequentialGuidGenerator.NewSequentialGuid(SequentialGuidType.SequentialAtEnd);

```