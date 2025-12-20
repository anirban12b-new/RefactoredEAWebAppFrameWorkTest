using OpenQA.Selenium;

namespace EAWebAppFrameWorkClasses.Extensions;
public class TableDataCollection
{
    public int RowNumber { get; set; }
    public string? ColumnName { get; set; }
    public string? ColumnValue { get; set; }
    public ColumnSpecialValue? ColumnSpecialValues { get; set; }
}
public enum ControlType
{
    HyperLink,
    Input,
    Option,
    Select
}
public class ColumnSpecialValue
{
    public IEnumerable<IWebElement>? ElementCollection { get; set; }
    public ControlType? ControlType { get; set; }
}


public static class HtmlTableExtensions
{
    private static List<TableDataCollection> ReadTable(IWebElement table)
    {
        var tableDataCollection = new List<TableDataCollection>();
        var columns = table.FindElements(By.TagName("th"));
        var rows = table.FindElements(By.TagName("tr"));
        var rowIndex = 0;
        foreach (var row in rows)
        {
            int colIndex = 0;
            var colDatas = row.FindElements(By.TagName("td"));
            if (colDatas.Count != 0)
                foreach (var colValue in colDatas)
                {
                    tableDataCollection.Add(new TableDataCollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text != "" ? columns[colIndex].Text : null,
                        ColumnValue = colValue.Text != "" ? colValue.Text : null,
                        ColumnSpecialValues = GetControl(colValue)

                    });
                    colIndex++;

                }

            rowIndex++;

        }

        return tableDataCollection;
    }

    private static ColumnSpecialValue? GetControl(IWebElement columnValue)
    {
        if (columnValue.FindElements(By.TagName("a")).Any())
            return new ColumnSpecialValue
            {
                ElementCollection = columnValue.FindElements(By.TagName("a")),
                ControlType = ControlType.HyperLink
            };

        if (columnValue.FindElements(By.TagName("input")).Any())
            return new ColumnSpecialValue
            {
                ElementCollection = columnValue.FindElements(By.TagName("input")),
                ControlType = ControlType.Input
            };

        if (columnValue.FindElements(By.TagName("select")).Any())
            return new ColumnSpecialValue
            {
                ElementCollection = columnValue.FindElements(By.TagName("select")),
                ControlType = ControlType.Select
            };

        if (columnValue.FindElements(By.TagName("option")).Any())
            return new ColumnSpecialValue
            {
                ElementCollection = columnValue.FindElements(By.TagName("option")),
                ControlType = ControlType.Option
            };

        return null;
    }


    private static IEnumerable<int> GetDynamicRowNumber(
        List<TableDataCollection> tableData,
        string refColumnName,
        string refColumnValue)
    {
        if (!tableData.Any())
            yield break;

        var matchingRows = tableData
            .Where(x =>
                x.ColumnName != null &&
                x.ColumnValue != null &&
                x.ColumnName.Equals(refColumnName, StringComparison.OrdinalIgnoreCase) &&
                x.ColumnValue.Equals(refColumnValue, StringComparison.OrdinalIgnoreCase))
            .Select(x => x.RowNumber)
            .Distinct();

        foreach (var row in matchingRows)
            yield return row;
    }
    
    
    public static void PerformActionOnCell(
        this IWebElement element,
        string refColumnName,
        string targetColumnName,
        string refColumnValue,
        string? controlToOperate = null)
    {
        var tableData = ReadTable(element);

        foreach (int rowNumber in GetDynamicRowNumber(tableData, refColumnName, refColumnValue))
        {
            var cell = tableData
                .SingleOrDefault(e =>
                    e.RowNumber == rowNumber &&
                    e.ColumnName != null &&
                    e.ColumnName.Equals(targetColumnName, StringComparison.OrdinalIgnoreCase))
                ?.ColumnSpecialValues;

            if (cell == null || cell.ElementCollection == null)
                continue;

            if (cell.ControlType == ControlType.HyperLink && controlToOperate != null)
            {
                var link = cell.ElementCollection
                    .SingleOrDefault(c =>
                        c.Text.Equals(controlToOperate, StringComparison.OrdinalIgnoreCase));

                link?.Click();
            }
        }
    }
}

