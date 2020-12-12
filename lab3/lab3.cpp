#include<iostream>

using namespace std;

int main()
{
	string input = "z:= false;\nz:= awdas xor 10;\n";
	//string input = ",";
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
		//if (tmp == ' ' || tmp == '\n') continue;

		if (tmp == ' ' || tmp == '\n' || tmp == '+' || tmp == '-' || tmp == '/' || tmp == '*' || tmp == '=' || tmp == '(' || tmp == ')' || tmp == '^' || tmp == ';' || tmp == ':' || tmp == '\0')
		{
#pragma region MyRegion
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
#pragma endregion
#pragma region :=
			if (tmp == ':' && input[i + 1] == '=')
			{
				i++;
				int check = -1;
				for (int i = 0; i < NumOfLex; i++)
					if (table[i].lexeme == ":=")
					{
						check = i;
						break;
					}
				if (check == -1)
				{
					table[NumOfLex].lexeme = ":=";
					NumOfLex++;
					output = output + "<lex" + char(NumOfLex + '0') + ">";
				}
				else
				{
					tmplex = "";
					output = output + "<lex" + char(check + '1') + ">";
				}
			}
#pragma endregion
			else
				if (tmp != ' ' && tmp != '\n')
					output.push_back(tmp);
			if (tmp == '\0')
				break;
		}
		else
		{
			/*true || false || and || or || xor || not*/
			if ((tmp == 't' || tmp == 'f' || tmp == 'a' || tmp == 'o' || tmp == 'x' || tmp == 'n') && !bLexeme)
			{
				string s = "";
				switch (tmp)
				{
				case 't':
					s = "true";
					break;
				case 'f':
					s = "false";
					break;
				case 'a':
					s = "and";
					break;
				case 'o':
					s = "or";
					break;
				case 'x':
					s = "xor";
					break;
				case 'n':
					s = "not";
					break;
				}
#pragma region MyRegion
				if (!s.empty())
				{
					int temp;
					bool checked = true;
					for (temp = 0; temp < s.length(); temp++)
					{
						if (input[i + temp] != s[temp])
							checked = false;
					}
					if (checked)
					{
						i += temp - 1;
						int check = -1;
						for (int i = 0; i < NumOfLex; i++)
							if (table[i].lexeme == s)
							{
								check = i;
								break;
							}
						if (check == -1)
						{
							table[NumOfLex].lexeme = s;
							NumOfLex++;

							output = output + "<lex" + char(NumOfLex + '0') + ">";
						}
						else
						{
							tmplex = "";
							output = output + "<lex" + char(check + '1') + ">";
						}
					}
					else
					{
						bLexeme = true;
						tmplex.push_back(tmp);
					}
				}
#pragma endregion
			}
			else
			{
				bLexeme = true;
				tmplex.push_back(tmp);
			}
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