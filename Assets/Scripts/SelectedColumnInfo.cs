using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SelectedColumnInfo {
    //store the selected column infomation 
    private static Dictionary<string,HashSet<string>> dictionary = new Dictionary<string, HashSet<string>>();
	private static string lastColumnName;
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
	/*set
        param: string:tableName string:columnName
    */
	public static void setLastColumnName(string tableName,string columnName)
	{
		lastColumnName = columnName;
	}

	/*get
        return a columnNameSet
    */
	public static string getLastColumnName()
	{
		return lastColumnName;
	}

    /*get
        param: string:tableName 
        return a columnNameSet
    */
    public static HashSet<string> getColumnNameSet(string tableName)
    {
		if (!dictionary.ContainsKey (tableName))
			return new HashSet<string> ();
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
