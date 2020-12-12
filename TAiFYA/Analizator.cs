using System;
using System.Text.RegularExpressions;
using HashTable;
using System.Collections.Generic;

namespace TAiFYA
{
    public class Analizator
    {
        public string Output;
        private Hashtable identityTable = new Hashtable();
        public List<IdentityTablesRow> tablesRows = new List<IdentityTablesRow>();
        public void Analyze(string Input)
        {

            const string RegFilter = @"(\b[a-zA-Z]+[a-zA-Z0-9]*\b)|(\b\d+\b)|(\b\d+\.?\d*\b)";
            const string RegWords = @"\b[a-zA-Z]+[a-zA-Z0-9]*\b";
            const string RegInt = @"\b\d+\b";
            const string RegDouble = @"\b\d+\.?\d+\b";
            const string RegSymbols = @"(\=|\+|\-|\*|\/|\(|\)|\^|:=)";
            const string RegLogicalOperations = @"(true|false|and|or|xor|not)";
            Output = Input;
            MatchCollection matchWords = Regex.Matches(Input, RegFilter, RegexOptions.None);
            
            foreach (Match m in matchWords)
                identityTable.Insert(m.Value.ToString(), m.Value.ToString());

            foreach (var item in identityTable.Items)
                foreach (var listItem in item.Value)
                {
                    IdentityTablesRow row = identityTable.Search(listItem.Value.lexeme);
                    Output = Regex.Replace(Output, $@"\b{listItem.Value.lexeme}\b", $@"<lex{ row.number}>");
                    tablesRows.Add(listItem.Value);
                }
        }
    }
}