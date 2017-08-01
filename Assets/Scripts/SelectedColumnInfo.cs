using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SelectedColumnInfo{
    //store the selected column infomation 
    private static Dictionary<string,HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
    /*set
        param: string:tableName string:columnName
    */
    public static void addColumnName(string tableName,string columnName)
    {
        if (!dictionary.ContainsKey(tableName))
        {
            dictionary.Add(tableName, new HashSet<string>());
        }
        HashSet<string> columnNameSet = dictionary[tableName];
        columnNameSet.Add(columnName);
    }
    /*get
        param: string:tableName 
        return a columnNameSet
    */
    public static HashSet<string> getColumnNameSet(string tableName)
    {
        return dictionary[tableName];
    }
    //just whether the set contains the column name
    //  param: string:tableName string:columnName
    //  return bool
    public static bool contains(string tableName,string columnName)
    {
        return dictionary[tableName].Contains(columnName);
    }
    //remove the column name in specific columnNameSet
    //  param: string:tableName string:columnName
    public static void removeColumnName(string tableName,string columnName)
    {
        if (contains(tableName, columnName))
        {
            dictionary[tableName].Remove(columnName);
        }
    }
}
