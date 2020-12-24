using System.Text.RegularExpressions;
using HashTable;
using System.Collections.Generic;

namespace TAiFYA
{
    public class Analizator
    {
        public string Output;
        private readonly Hashtable identityTable = new Hashtable();
        public List<IdentityTablesRow> tablesRows = new List<IdentityTablesRow>();
        public void Analyze(string Input)
        {

            const string RegFilter = @"(\b[a-zA-Z]+[a-zA-Z0-9]*\b)|(\b\d+\b)|(\b\d+\.?\d*\b)";           
            Output = Input;
            MatchCollection matchWords = Regex.Matches(Input, RegFilter, RegexOptions.None);
            
            foreach (Match m in matchWords)
                identityTable.Insert(m.Value.ToString(), m.Value.ToString());

            foreach (var item in identityTable.Items)
                foreach (var listItem in item.Value)
                {
                    IdentityTablesRow row = identityTable.Search(listItem.Value.lexeme);
                    Output = Regex.Replace(Output, $@"\b{listItem.Value.lexeme}\b", $@"<lex{row.number}>");
                    tablesRows.Add(listItem.Value);
                }
        }
    }
}