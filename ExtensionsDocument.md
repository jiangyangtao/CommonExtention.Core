# Extensions 扩展

> 统一命名空间：`using CommonExtention.Core.Extensions;`  

## Array 扩展

> 部分代码尚未测试，所以没有写进文档，请谨慎使用。

- 将一种将当前数组转换为另一种类型的数组

``` csharp

var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var stringArray = intArray.ConvertAll(a => a.ToString());

```

- 将当前数组转换为 string[]

``` csharp

var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var stringArray = intArray.ToStringArray();

```

- 将当前字符串换为 string[]

``` csharp

var str = "1,2,3,4,5,6,7,8,9";
var stringArray = str.ToSplitArray();

```

- 将当前数组转化为字符串的表示形式

``` csharp

var stringArray = new string[]{"1","2","3","4","5","6","7","8","9"};
var str = stringArray.ToStringValue();

// output: "1,2,3,4,5,6,7,8,9"

```

- 对当前数组的每个元素执行指定操作

``` csharp

var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// ForEach 扩展不可使用 continue
intArray.ForEach(item =>
{
    // TO DO
});

```

- 对当前数组的每个元素执行指定操作

``` csharp

var intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// ForEach 扩展不可使用 continue
intArray.ForEach((item, index) =>
{
    // TO DO
});

```

<br />
<br />

## ActionDescriptor 扩展

> 获取当前 ActionDescriptor 的 ControllerName

``` sharp

ActionDescriptor.ControllerName();

```

<br />
<br />

## Database 扩展

- 创建一个原始 Sql 查询，将该查询的结果返回给 DataTable

``` csharp

DbContext.Database.SqlQuery(sql, parameters);

```

- 创建一个原始 Sql 查询，将该查询的结果返回给 DataTable

``` csharp

async DbContext.Database.SqlQueryAsync(sql, parameters);

```

- 创建一个原始 Sql 查询，将该查询的结果返回给 IEnumerable<T>

``` csharp

DbContext.Database.SqlQuery(sql, parameters);

```

- 创建一个原始 Sql 查询，将该查询的结果返回给 IEnumerable<T>

``` csharp

async DbContext.Database.SqlQueryAsync(sql, parameters);

```

- 创建一个原始 Sql 查询，将该查询的结果返回给 DataSet

``` csharp

DbContext.Database.SqlQueryToDataSet(sql, parameters);

```

<br />
<br />

## DataColumnCollection 扩展

- 对 DataColumnCollection 的每个元素执行指定操作

``` csharp

DataTable.Columns.ForEach(item =>
{
    // TO DO
});

```

- 对 DataColumnCollection 的每个元素执行指定操作

``` csharp

DataTable.Columns.ForEach((item, index) =>
{
    // TO DO
});

```

<br />
<br />

## DataRowCollection 扩展

- 对 DataRowCollection 的每个元素执行指定操作

``` csharp

DataTable.Rows.ForEach(item =>
{
    // TO DO
});

```

- 对 DataRowCollection 的每个元素执行指定操作

``` csharp

DataTable.Rows.ForEach((item, index) =>
{
    // TO DO
});

```

<br />
<br />

## DataSet 扩展

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(formatting);

```

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(settings);

```

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(converters);

```

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(formatting, settings);

```

- 将当前 DataSet 对象转换为 Json 数组字符串

``` csharp

DataSet.ToJson(formatting, converters);

```

<br />
<br />

## DataTableCollection 扩展

- 对 DataTableCollection 的每个元素执行指定操作

``` csharp

DataSet.Tables.ForEach(item =>
{
    // TO DO
});

```

- 对 DataTableCollection 的每个元素执行指定操作

``` csharp

DataTable.Rows.ForEach((item, index) =>
{
    // TO DO
});

```

<br />
<br />

## DataTable 扩展

- 将当前 DataTable 对象转换为 Json 字符串

``` csharp

DataTable.ToJsonString(formatting);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(formatting);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(settings);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(converters);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(formatting, settings);

```

- 将当前 DataTable 对象转换为 Json 数组字符串

``` csharp

DataTable.ToJsonArray(formatting, converters);

```

- 将当前 DataTable 对象转换为 List

``` csharp

DataTable.ToList<T>();

```

- 将当前 DataTable 对象用异步方式转换为 List

``` csharp

async DataTable.ToListAsync<T>();

```

- 将当前 DataTable 对象转换为 ArrayList 对象

``` csharp

DataTable.ToArrayList();

```

- 将当前 DataTable 对象写入 MemoryStream

``` csharp

DataTable.WriteToMemoryStream(action, sheetsName);

```

- 将当前 DataTable 对象用异步方式写入 MemoryStream

``` csharp

async DataTable.WriteToMemoryStreamAsync(action, sheetsName);

```

- 清除当前 DataTable 对象的空行

``` csharp

DataTable.ClearEmptyRow();

```

<br />
<br />

## DateTime 扩展

- Sql Server 数据库 DateTime 初始值

``` csharp

// 公元 1900 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
DateTimeExtensions.MsSQLDateTimeInitial

```

- Sql Server 数据库 DateTime 最小值

``` csharp

// 公元 1900 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
DateTimeExtensions.MsSQLDateTimeMinValue

```

- Sql Server 数据库 DateTime 最大值

``` csharp

// 公元 9999 年 12 月 31 号 11 点 59 分 59 秒 999 毫秒
DateTimeExtensions.MsSQLDateTimeMaxValue

```

- MySql 数据库 DateTime 初始值

``` csharp

// 公元 1753 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
DateTimeExtensions.MySqlDateTimeInitial

```

- MySql 数据库 DateTime 最小值

``` csharp

// 公元 1753 年 1 月 1 号 00 点 00 分 00 秒 000 毫秒
DateTimeExtensions.MySqlDateTimeMinValue

```

- MySql 数据库 DateTime 最大值

``` csharp

// 公元 9999 年 12 月 31 号 11 点 59 分 59 秒 999 毫秒
DateTimeExtensions.MySqlDateTimeMaxValue

```

- 将当前 DateTime 实例转换为 Unix 时间

``` csharp

DateTime.Now.ToUnixTime();

```

- 将当前 DateTime 实例转换为格式化后的日期的字符串表示形式

``` csharp

// 默认格式：yyyy-MM-dd
DateTime.Now.ToFormatDate();

```

- 将当前 DateTime 实例转换为格式化后的日期时间的字符串表示形式

``` csharp

// 默认格式：yyyy-MM-dd HH:mm:ss
DateTime.Now.ToFormatDateTime();

```

- 从当前 DateTime 实例中计算出与当前时间的时间差

``` csharp

DateTime.TimeRange();

```

- 从当前 DateTime 实例中计算出与当前时间之前的时间差

``` csharp

DateTime.BeforeTimeRange();

```

- 从当前 DateTime 实例中计算出与当前时间之后的时间差

``` csharp

DateTime.AfterTimeRange();

```

- 从当前 DateTime 实例中取得当前月的第一天

``` csharp

DateTime.Now.FirstDayOfMonth();

```

- 从当前 DateTime 实例中取得当前月的最后一天

``` csharp

DateTime.Now.LastDayOfMonth();

```

- 从当前 DateTime 实例中取得当前周以星期天开始的第一天

``` csharp

DateTime.Now.FirstDayOfWeekFromSunday();

```

- 从当前 DateTime 实例中取得当前周以星期一开始的第一天

``` csharp

DateTime.Now.FirstDayOfWeekFromMonday();

```

- 从当前 DateTime 实例中取得当前周以星期天开始的最后一天

``` csharp

DateTime.Now.LastDayOfWeekFromSunday();

```

- 从当前 DateTime 实例中取得当前周以星期一开始的最后一天

``` csharp

DateTime.Now.LastDayOfWeekFromMonday();

```

<br />
<br />

## decimal 扩展

- 将此实例的数值转换为其千分位的字符串表示形式

``` csharp

decimal.ToThousand();

```

<br />
<br />

## double 扩展

- 返回 length 对应的 Size

``` csharp

double.FileSize();

```

- 将此实例的数值转换为其千分位的字符串表示形式

``` csharp

double.ToThousand();

```

<br />
<br />

## Exception 扩展

- 返回 Exception 对象中的 InnerException

``` csharp

Exception.GetInnerException();

```

- 返回当前 Exception 对象中 InnerException 的 Message

``` csharp

Exception.ExceptionMessage();

```

- 将当前 Exception 对象用异步方式写入日志

``` csharp

Exception.WriteLogAsync();

```

<br />
<br />

## FileInfo 扩展

- 将当前 FileInfo 对象转换成 MemoryStream 对象

``` csharp

FileInfo.ToMemoryStream();

```

- 获取当前 FileInfo 对象的无符号字节数组

``` csharp

FileInfo.GetBuffer();

```

<br />
<br />

## Filter 扩展

- 指示 FilterDescriptor 集合中是否存在指定的 Attribute 或者 Filter

``` csharp

Filters.HasFilterOrAttribute(type);

```

- 指示 IFilterMetadata 集合中是否存在指定的 Filter

``` csharp

Filters.HasFilter(type);

```

<br />
<br />

## Guid 扩展

- 指示指定的 Guid 是否为 System.Guid.Empty

``` csharp

Guid.IsEmpty();

```

- 指示指定的 Guid 是否不为 System.Guid.Empty

``` csharp

Guid.NotEmpty();

```

- 指示指定的 Guid? 是 null 还是 System.Guid.Empty

``` csharp

Guid?.IsNullOrEmpty();

```

- 指示指定的 Guid? 是否为 null

``` csharp

Guid?.IsNull();

```

- 指示指定的 Guid? 是否不为 null

``` csharp

Guid?.NotNull();

```

- 指示指定的 Guid? 不为 null 和 System.Guid.Empty

``` csharp

Guid?.NotNullAndEmpty();

```

<br />
<br />

## HttpRequest 扩展

- 获取当前请求的参数

``` csharp

HttpRequest.GetParamsString();

```

- 获取有关当前请求的 Url 的信息

``` csharp

HttpRequest.Url();

```

- 获取当前请求的站点

``` csharp

HttpRequest.Origin();

```

- 获取当前绝对 Url

``` csharp

HttpRequest.AbsoluteUrl();

```

- 获取当前请求 Header 的值

``` csharp

HttpRequest.GetHeaderValue(key);

```

- 获取当前请求 UserAgent

``` csharp

HttpRequest.UserAgent(key);

```

<br />
<br />

## ICollection 扩展

- 对 ICollection 的每个元素执行指定操作

``` csharp

ICollection<T>.ForEach(item => {
    // TO DO
});

```

- 对 ICollection 的每个元素执行指定操作

``` csharp

ICollection<T>.ForEach((item, index) => {
    // TO DO
});

```

<br />
<br />

## IEnumerable 扩展

- 对 ICollection 的每个元素执行指定操作

``` csharp

IEnumerable<T>.ForEach(item => {
    // TO DO
});

```

- 对 ICollection 的每个元素执行指定操作

``` csharp

IEnumerable<T>.ForEach((item, index) => {
    // TO DO
});

```

- 指示 CustomAttributeData 公开枚举器中是否存在指定的 Attribute

``` csharp

IEnumerable<CustomAttributeData>.HasAttribute(type);

```

<br />
<br />

## IFormCollection 扩展

- 获取当前 IFormCollection 集合的指定值

``` csharp

IFormCollection.GetValue(type);

```

- 将当前 FormCollection 集合转换为 Json 数组字符串

``` csharp

IFormCollection.ToJson();

```

## IHeaderDictionary 扩展

- 获取当前请求的 UserAgent

``` csharp

IHeaderDictionary.UserAgent(type);

```

- 获取当前请求的 Content-Type

``` csharp

IHeaderDictionary.ContentType();

```

<br />
<br />

## long 扩展

- 将此实例的Unix时间格式的数值转换为DateTime对象

``` csharp

long.ToDateTime();

```

- 返回 length 对应的 Size

``` csharp

long.FileSize();

```

- 将此实例的数值转换为其千分位的字符串表示形式

``` csharp

long.ToThousand();

```

<br />
<br />

## int 扩展

- 返回 length 对应的 Size

``` csharp

int.FileSize();

```

- 将此实例的数值转换为其千分位的字符串表示形式

``` csharp

int.ToThousand();

```

<br />
<br />

## Json 扩展

- 返回 Key 对应的字符串表示形式的值

``` csharp

JObject.GetValue(key);

```

- 返回 Key 对应的指定类型的值

``` csharp

JObject.GetValue(key);

```

- 返回 Key 对应的键值对

``` csharp

JObject.GetKeyValue(key);

```

<br />
<br />

## List 扩展

- 将当前 List 集合转换为 DataTable

``` csharp

List<T>.ToDataTable();

```

- 将当前 List 对象转换为 Json 字符串

``` csharp

List<T>.ToJsonString(formatting);

```

- 将当前 List 对象转换为 Json 数组字符串

``` csharp

List<T>.ToJsonArray(formatting);

```

- 将当前 List 对象转换为 Json 数组字符串

``` csharp

List<T>.ToJsonArray(settings);

```

- 将当前 List 对象转换为 Json 数组字符串

``` csharp

List<T>.ToJsonArray(converters);

```

- 将当前 List 对象转换为 Json 数组字符串

``` csharp

List<T>.ToJsonArray(formatting, settings);

```

- 将当前 List 对象转换为 Json 数组字符串

``` csharp

List<T>.ToJsonArray(formatting, converters);

```

- 对当前 List 集合的每个元素执行指定操作

``` csharp

List<T>.ForEach((item, index) => {
    // TO DO
});

```

- 清除当前 List 中的空元素

``` csharp

List<T>.ClearNullItem();

```

<br />
<br />

## NameValueCollection 扩展

- 对 ICollection 的每个元素执行指定操作

``` csharp

ICollection<T>.ForEach(item => {
    // TO DO
});

```

- 对 ICollection 的每个元素执行指定操作

``` csharp

ICollection<T>.ForEach((item, index) => {
    // TO DO
});

```

- 将当前集合序列化成 Json 的字符串表示形式

``` csharp

ICollection<T>.ToJson();

```

<br />
<br />

## Nullable 扩展

- 将当前 short? 对象转换为其等效的安全值

``` csharp

short?.ToInt16();

```

- 将当前 int? 对象转换为其等效的安全值

``` csharp

int?.ToInt16();

```

- 将当前 long? 对象转换为其等效的安全值

``` csharp

long?.ToInt16();

```

- 将当前 float? 对象转换为其等效的安全值

``` csharp

float?.ToInt16();

```

- 将当前 double? 对象转换为其等效的安全值

``` csharp

double?.ToInt16();

```

- 将当前 decimal? 对象转换为其等效的安全值

``` csharp

decimal?.ToInt16();

```

- 将当前 DateTime? 对象转换为其等效的安全值

``` csharp

DateTime?.ToInt16();

```

- 将当前 short? 对象转换为其千分位的字符串表示形式

``` csharp

short?.ToThousand();

```

- 将当前 int? 对象转换为其千分位的字符串表示形式

``` csharp

int?.ToThousand();

```

- 将当前 long? 对象转换为其千分位的字符串表示形式

``` csharp

long?.ToThousand();

```

- 将当前 float? 对象转换为其千分位的字符串表示形式

``` csharp

float?.ToThousand();

```

- 将当前 double? 对象转换为其千分位的字符串表示形式

``` csharp

double?.ToThousand();

```

- 将当前 decimal? 对象转换为其千分位的字符串表示形式

``` csharp

decimal?.ToThousand();

```

- 将当前 DateTime? 对象转换为格式化后的日期字符串

``` csharp

DateTime?.ToFormatDate();

```

- 将当前 DateTime? 对象转换为格式化后的日期时间字符串

``` csharp

DateTime?.ToFormatDateTime();

```

<br />
<br />

## Object 扩展

> 对当前类的每个属性执行指定操作

``` csharp

T.ForIn<T>();

```

> 指示指定的 object 对象是否不为 null

``` csharp

csharp bool NotNull();

```

> 指示指定的 object 对象不是 null 和 System.String.Empty 字符串

``` csharp

object.NotNullAndEmpty();

```

> 指示指定的 object 对象是否为 null

``` csharp

object.IsNull();

```

> 指示指定的 object 对象是 null 还是 System.String.Empty 字符串

``` csharp

object.IsNullOrEmpty();

```

> 将指定的 object 对象转换不为 null 的 System.String 表示形式

``` csharp

object.ToNotNullString();

```

> 将指定的 object 对象转换为去除空格后的 System.String 表示形式

``` csharp

object.ToNotSpaceString();

```

> 指示指定的 object 是否为等效的 String 类型

``` csharp

object.IsString();

```

> 指示指定的 object 是否为等效的 Int16 类型

``` csharp

object.IsInt16();

```

> 指示指定的 object 是否为等效的 Int32 类型

``` csharp

object.IsInt();

```

> 指示指定的 object 是否为等效的 Int64 类型

``` csharp

object.IsInt64();

```

> 指示指定的 object 是否为等效的 Decimal 类型

``` csharp

object.IsDecimal();

```

> 指示指定的 object 是否为等效的 Single 类型

``` csharp

object.IsSingle();

```

> 指示指定的 object 是否为等效的 Double 类型

``` csharp

object.IsDouble();

```

> 指示指定的 object 是否为等效的 DadeTime 对象

``` csharp

object.IsDateTime();

```

> 指示指定的 object 是否为等效的 Boolean 类型

``` csharp

object.IsBoolean();

```

> 将数字形式的 object 对象转换为其等效的 Int16 的值

``` csharp

object.ToInt16();

```

> 将数字形式的 object 对象转换为其等效的 Int32 的值

``` csharp

object.ToInt();

```

> 将数字形式的 object 对象转换为其等效的 Int64 的值

``` csharp

object.ToInt64();

```

> 将数字形式的 object 对象转换为其等效的 Single 的值

``` csharp

object.ToSingle();

```

> 将数字形式的 object 对象转换为其等效的 Double 的值

``` csharp

object.ToDouble();

```

> 将数字形式的 object 对象转换为其等效的 Decimal 的值

``` csharp

object.ToDecimal();

```

> 将时间形式的 object 对象转换为其等效的 DateTime 对象

``` csharp

object.ToDateTime();

```

> 将布尔形式的 object 对象转换为其等效的 Boolean 的值

``` csharp

object.ToBoolean();

```

> 将 Guid 形式的 object 对象转换为其等效的 Guid 的值

``` csharp

object.ToGuid();

```

> 将 Guid 形式的 object 对象转换为其等效的 Guid 的值

``` csharp

object.ToGuid();

```

> 将数字形式的 object 对象转换为其等效的 short? 的值

``` csharp

object.ToNullableInt16();

```

> 将数字形式的 object 对象转换为其等效的 int? 的值

``` csharp

object.ToNullableInt();

```

> 将数字形式的 object 对象转换为其等效的 long? 的值

``` csharp

object.ToNullableInt64();

```

> 将数字形式的 object 对象转换为其等效的 float? 的值

``` csharp

object.ToNullableSingle();

```

> 将数字形式的 object 对象转换为其等效的 double? 的值

``` csharp

object.ToNullableDouble();

```

> 将数字形式的 object 对象转换为其等效的 decimal? 的值

``` csharp

 object.ToNullableDecimal();

```

> 将时间形式的 object 对象转换为其等效的 DateTime? 对象

``` csharp

object.ToNullableDateTime();

```

> 将布尔形式的 object 对象转换为其等效的 bool? 的值

``` csharp

object.ToNullableBoolean();

```

> 将 Guid 形式的 object 对象转换为其等效的 Guid? 的值

``` csharp

object.ToNullableGuid();

```

> 将 Guid 形式的 object 对象转换为其等效的 Guid? 的值

``` csharp

object.ToNullableGuid();

```

## RouteData 扩展

> 获取当前 RouteData 的 ActionName

``` csharp

RouteData.ActionName();

```

> 获取当前 RouteData 的 ControllerName

``` csharp

RouteData.ControllerName();

```

<br />
<br />

## short 扩展

> 将此实例的数值转换为其千分位的字符串表示形式

``` csharp

short.ToThousand();

```

<br />
<br />

## float 扩展

> 将此实例的数值转换为其千分位的字符串表示形式

``` csharp

float.ToThousand();

```

<br />
<br />

## String 扩展

> 初始化一个字符串形式的 GUID 对象

``` csharp

string.NewGuid();

```

> 将字符串形式的Unix时间转换为 DateTime 对象

``` csharp

string.UnixToDateTime();

```

> 指示指定的字符串是否为 null

``` csharp

string.IsNull();

```

> 指示指定的字符串是否为 System.String.Empty 字符串

``` csharp

string.IsEmpty();

```

> 指示指定的字符串是 null 还是 System.String.Empty 字符串

``` csharp

string.IsNullOrEmpty();

```

> 指示指定的字符串是否不为 null

``` csharp

string.NotNull();

```

> 指示指定的字符串是否不为 System.String.Empty 字符串

``` csharp

string.NotEmpty();

```

> 指示指定的字符串不为 null 和 System.String.Empty 字符串

``` csharp

string.NotNullAndEmpty();

```

> 指示指定的字符串是否为电子邮箱

``` csharp

string.IsEmail();

```

> 指示指定的字符串是否为中华人民共和国第二代身份证号码

``` csharp

string.IsChinaIdentityNumber();

```

> 指示指定的字符串是否为等效的 Int16 类型

``` csharp

string.IsInt16();

```

> 指示指定的字符串是否为等效的 Int32 类型

``` csharp

string.IsInt();

```

> 指示指定的字符串是否为等效的 Int64 类型

``` csharp

string.IsInt64();

```

> 指示指定的字符串是否为等效的 Decimal 类型

``` csharp

string.IsDecimal();

```

> 指示指定的字符串是否为等效的 Single 类型

``` csharp

string.IsSingle();

```

> 指示指定的字符串是否为等效的 Double 类型

``` csharp

string.IsDouble();

```

> 指示指定的字符串是否为等效的 DadeTime 对象

``` csharp

string.IsDateTime();

```

> 指示指定的字符串是否为等效的 Boolean 类型

``` csharp

string.IsBoolean();

```

> 指示指定的字符串是否为等效的 Guid 类型

``` csharp

string.IsGuid();

```

> 指示指定的字符串是否为等效的 Guid 类型

``` csharp

string.IsGuid();

```

> 指示指定要加密的字符串进行 MD5 算法的16位小写加密

``` csharp

string.ToMD5();

```

> 指示指定要加密的字符串进行 MD5 算法的16位大写加密

``` csharp

string.ToMD5Upper();

```

> 指示指定要加密的字符串进行 MD5 算法的32位小写加密

``` csharp

string.ToMD5Lower32();

```

> 指示指定要加密的字符串进行 MD5 算法的32位大写加密

``` csharp

string.ToMD5Upper32();

```

> 指示指定要加密的字符串进行 MD5 混淆加密

``` csharp

string.ToMD5Confusion();

```

> 指示指定要加密的字符串进行 SHA1 算法小写加密

``` csharp

string.ToSHA1();

```

> 指示指定要加密的字符串进行 SHA1 算法大写加密

``` csharp

string.ToSHA1Upper();

```

> 指示指定要加密的字符串进行 SHA1 算法混淆加密

``` csharp

string.ToSHA1Confusion();

```

> 指示指定要加密的字符串进行 SHA256 算法小写加密

``` csharp

string.ToSHA256();

```

> 指示指定要加密的字符串进行 SHA256 算法大写加密

``` csharp

string.ToSHA256Upper();

```

> 指示指定要加密的字符串进行 SHA384 算法小写加密

``` csharp

string.ToSHA384();
  
```

> 指示指定要加密的字符串进行 SHA384 算法大写加密

``` csharp

string.ToSHA384Upper();

```

> 指示指定要加密的字符串进行 SHA512 算法小写加密

``` csharp

string.ToSHA512();

```

> 指示指定要加密的字符串进行 SHA512 算法大写加密

``` csharp

string.ToSHA512Upper();

```

> 指示指定要加密的字符串进行 DES 算法加密

``` csharp

string.ToDesEncrypt();

```

> 指示指定要解密的字符串进行 DES 算法解密

``` csharp

string.ToDesDecrypt();

```

> 指示指定要加密的字符串进行 3DES 算法加密

``` csharp

string.To3DesEncrypt();

```

> 指示指定要解密的字符串进行 3DES 算法解密

``` csharp

string.To3DesDecrypt();

```

> 指示指定要解密的字符串进行 AES 算法加密(CBC模式)

``` csharp

string.ToAesEncrypt();

```

> 指示指定要解密的字符串进行 AES 算法解密(CBC模式)

``` csharp

string.ToAesDecrypt();

```

> 将指定的字符串去除空格

``` csharp

string.ToNotSpaceString();

```

> 将字符串的表示形式转换不为 null 的 System.String 的值

``` csharp

string.ToNotNullString();

```

> 将数字的字符串表示形式转换为其等效的 Int16 的值

``` csharp

string.ToInt16();

```

> 将数字的字符串表示形式转换为其等效的 Int32 的值

``` csharp

string.ToInt();

```

> 将数字的字符串表示形式转换为其等效的 Int64 的值

``` csharp

string.ToInt64();

```

> 将数字的字符串表示形式转换为其等效的 Single 的值

``` csharp

string.ToSingle();

```

> 将数字的字符串表示形式转换为其等效的 Double 的值

``` csharp

string.ToDouble();

```

> 将数字的字符串表示形式转换为其等效的 Decimal 的值

``` csharp

string.ToDecimal();

```

> 将时间的字符串表示形式转换为其等效的 DateTime 对象

``` csharp

string.ToDateTime();

```

> 将布尔的字符串表示形式转换为其等效的 Boolean 的值

``` csharp

string.ToBoolean();

```

> 将 Guid 的字符串表示形式转换为其等效的 Guid 的值

``` csharp

string.ToGuid();

```

> 将 Guid 的字符串表示形式转换为其等效的 Guid 的值

``` csharp

string.ToGuid();

```

> 将数字的字符串表示形式转换为其等效的 short? 的值

``` csharp

string.ToNullableInt16();

```

> 将数字的字符串表示形式转换为其等效的 int? 的值

``` csharp

string.ToNullableInt();

```

> 将数字的字符串表示形式转换为其等效的 long? 的值

``` csharp

string.ToNullableInt64();

```

> 将数字的字符串表示形式转换为其等效的 float? 的值

``` csharp

string.ToNullableSingle();

```

> 将数字的字符串表示形式转换为其等效的 double? 的值

``` csharp

string.ToNullableDouble();

```

> 将数字的字符串表示形式转换为其等效的 decimal? 的值

``` csharp

string.ToNullableDecimal();

```

> 将时间的字符串表示形式转换为其等效的 DateTime? 对象

``` csharp

string.ToNullableDateTime();

```

> 将布尔的字符串表示形式转换为其等效的 bool? 的值

``` csharp

string.ToNullableBoolean();

```

> 将 Guid 的字符串表示形式转换为其等效的 Guid? 的值

``` csharp

string.ToNullableGuid();

```

> 将 Guid 的字符串表示形式转换为其等效的 Guid? 的值

``` csharp

string.ToNullableGuid();

```

> 将 Json 的字符串表示形式转换为 Newtonsoft.Json.Linq.JObject 对象

``` csharp

string.ToJson();

```

> 将 Json 数组的字符串表示形式转换为 Newtonsoft.Json.Linq.JArray 对象

``` csharp

string.ToJsonArray();

```

> 将 Base64 字符串表示形式转换为等效的字符串

``` csharp

string.FromBase64ToString();

```

> 将当前字符串转换为 Base64 字符串表示形式

``` csharp

string.ToBase64String();

```

> 将当前字符串转换为一个字节序列

``` csharp

string.ToByte();

```

> 计算指定字符串的16位 MD5 的哈希/散列值

``` csharp

string.To16MD5Hash();

```

> 计算指定字符串的32位 MD5 的哈希/散列值

``` csharp

string.To32MD5Hash();

```

> 计算指定字符串的 SHA1 算法的哈希/散列值

``` csharp

string.ToSHA1Hash();

```

> 获取指定的字符串中包含的后缀名

``` csharp

string.ExtendName();

```

> 获取当前电子邮箱的字符串表示形式的前缀

``` csharp

string.EmailPrefix();

```

> 获取 Json 的字符串表示形式中的值

``` csharp

string.GetJsonValue(key);

```

> 获取 Json 的字符串表示形式中的值

``` csharp

string.GetJsonValue(key);

```

> 获取指定的中华人民共和国第二代身份证号码字符串的出生日期

``` csharp

string.GetDateOfBirthOfChinaIDNumber();

```

> 获取指定的中华人民共和国第二代身份证号码字符串的当前年龄

``` csharp

string.GetAgeOfChinaIDNumber();

```

> 获取指定的中华人民共和国第二代身份证号码字符串的性别的文字

``` csharp

string.GetGenderTextOfChinaIDNumber();

```

> 获取指定的中华人民共和国第二代身份证号码字符串的性别的数字

``` csharp

string.GetGenderCodeOfChinaIDNumber();

```