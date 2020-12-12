#include<iostream>

using namespace std;

int main()
{
	string input = "z=(x*y^2-1)*(x*y+120)*5";
	string output = "";

	int TMP = 50;
	struct row
	{
		string lexeme;
		string type;
	}*table = new row[TMP];

	bool bLexeme = false;
	int NumOfLex = 0;
	string tmplex = "";
	for (int i = 0; i <= input.length(); i++)
	{
		unsigned char tmp = input[i];
		if (tmp == ' ') continue;
		if (tmp == '+' || tmp == '-' || tmp == '/' || tmp == '*' || tmp == '=' || tmp == '(' || tmp == ')' || tmp == '^' || tmp == '\0')
		{
			if (bLexeme)
			{
				bLexeme = false;
				int check = -1;
				for (int i = 0; i < NumOfLex; i++)
					if (table[i].lexeme == tmplex)
					{
						check = i;
						break;
					}
				if (check == -1)
				{
					table[NumOfLex].lexeme = tmplex;
					NumOfLex++;
					tmplex = "";
					output = output + "<lex" + char(NumOfLex + '0') + ">";
				}
				else
				{
					tmplex = "";
					output = output + "<lex" + char(check + '1') + ">";
				}
			}
			output.push_back(tmp);
			if (tmp == '\0')
				break;
		}
		else
		{
			bLexeme = true;
			tmplex.push_back(tmp);
		}
	}
	cout << input << endl;
	for (int i = 0; i < NumOfLex; i++)
	{
		cout << "lex" << i + 1 << '\t' << table[i].lexeme << endl;
	}
	cout << output << endl;
	system("pause");
}