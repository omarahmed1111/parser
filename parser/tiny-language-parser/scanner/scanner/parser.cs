using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scanner
{
    class parser
    {
        int idx;
        List<node> tkns;
        public bool error;
        int input_sz;
        public parser(string text_file)
        {
            idx = 0;
            error = false;
            string value="";
            string token="";
            bool traverse = false;
            tkns = new List<node>();
            for(int i = 0; i < text_file.Length; i++)
            {
                if (text_file[i] == '\r'|| text_file[i] == ' '|| text_file[i] == '\t') continue;
                if (text_file[i] == '\n') {
                    if (!traverse) continue;
                    traverse = false;
                    node temp = new node(token, value);
                    token = ""; value = "";
                    tkns.Add(temp);
                }
                else if (text_file[i] == ',') traverse = true;
                else if (!traverse)
                {
                    value += text_file[i];
                }
                else
                {
                    token += text_file[i];
                }
            }
            if (value.Length > 0)
            {
                node temp = new node(token, value);
                token = ""; value = "";
                tkns.Add(temp);
            }
            input_sz = tkns.Count;
        }
        public tree exp()
        {
            tree temp = new tree(false, ""), newtemp = new tree(false, "");
            temp = term();
            while (tkns[idx].tknType =="PLUS" || tkns[idx].tknType == "MINUS")
            {
                newtemp.type = true; newtemp.text = tkns[idx].tknValue;
                idx++;
                
                newtemp.children.Add(temp);
                tree temp2 = new tree(false, "");
                temp2 = term();
                newtemp.children.Add(temp2);
                temp = newtemp;
            }

            return temp;
        }
        public tree term()
        {
            tree temp = new tree(false, ""), newtemp = new tree(false, "");
            temp = factor();
            while(tkns[idx].tknType== "MULT" || tkns[idx].tknType == "DIV")
            {
                newtemp.type = true; newtemp.text = tkns[idx].tknValue;
                idx++;

                newtemp.children.Add(temp);
                tree temp2 = new tree(false, "");
                temp2 = factor();
                newtemp.children.Add(temp2);
                temp = newtemp;
            }
            return temp;
        }
        public tree factor()
        {
            tree temp = new tree(false,"");
            if (tkns[idx].tknType == "OPENBRACKET")
            {
                if (match("OPENBRACKET")) { }
                else {
                    error = true;
                }//error
                temp = exp();
                if (match("CLOSEDBRACKET")) { }
                else {
                    error = true;
                }//error

            }
            else if (tkns[idx].tknType == "NUMBER")
            {
                temp.type = true;
                temp.text = tkns[idx].tknValue;
                idx++;
            }
            else if(tkns[idx].tknType == "IDENTIFIER")
            {
                temp.type = true;
                temp.text = tkns[idx].tknValue;
                idx++;
            }
            else
                error = true;
            return temp;
        }

        public tree parse(string t)
        {
            tree first = new tree(false,"");
            bool begin = true;
            while (true) {
                if (idx >= input_sz) break;
                if (tkns[idx].tknType == "READ")
                {

                    string value = "read \n";
                    idx++;

                    if (match("IDENTIFIER"))
                    {
                        value += tkns[idx - 1].tknValue;
                    }
                    else {
                        error = true;
                    }//error

                    
                    if (tkns[idx].tknType == "SEMICOLON") {
                        idx++;
                        if (t == "IF" && (tkns[idx].tknType != "END" && tkns[idx].tknType != "ELSE")) { }
                        else if (t == "REPEAT" && tkns[idx].tknType != "UNTIL") { }
                        else if (t == "" && idx != input_sz) { }
                        else error = true;
                    }
                    else
                    {
                        if (t == "IF" &&( tkns[idx].tknType == "END"||tkns[idx].tknType=="ELSE")) { }
                        else if (t == "REPEAT" && tkns[idx].tknType == "UNTIL") { }
                        else if (t == "" && idx == input_sz) { }
                        else error = true;
                    }

                    if (begin)
                    {
                        begin = false;
                        first.text = value;
                    }
                    else
                    {
                        tree temp = new tree(false, value);
                        first.friends.Add(temp);
                    }
                }
                else if (tkns[idx].tknType == "WRITE")
                {
                    tree temp = new tree(false, "write");
                    idx++;
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    tree temp3 = new tree(false, "");
                    temp3 = exp();

                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    temp.children.Add(temp3);
                    if (tkns[idx].tknType == "SEMICOLON")
                    {
                        idx++;
                        if (t == "IF" && (tkns[idx].tknType != "END" && tkns[idx].tknType != "ELSE")) { }
                        else if (t == "REPEAT" && tkns[idx].tknType != "UNTIL") { }
                        else if (t == "" && idx != input_sz) { }
                        else error = true;
                    }
                    else
                    {
                        if (t == "IF" && (tkns[idx].tknType == "END" || tkns[idx].tknType == "ELSE")) { }
                        else if (t == "REPEAT" && tkns[idx].tknType == "UNTIL") { }
                        else if (t == "" && idx == input_sz) { }
                        else error = true;
                    }

                    if (begin)
                    {
                        begin = false;
                        first = temp;
                    }
                    else
                    {
                        first.friends.Add(temp);
                    }
                }
                else if(tkns[idx].tknType == "REPEAT")
                {
                    tree temp = new tree(false, "repeat");
                    idx++;
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    tree temp2 = new tree(false, "");
                    temp2 = parse("REPEAT");
                    temp.children.Add(temp2);
                    
                    if (match("UNTIL"))
                    {
                        
                    }
                    else {
                        error = true;
                    } //error
                    //condition of until
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    tree temp3 = new tree(false, "");
                    temp3 = exp();
                    
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    tree temp4 = new tree(false, "");
                    temp4 = cmpOP();
                   
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    tree temp5 = new tree(false, "");
                    temp5 = exp();
                    
                    if (match("SEMICOLON"))
                    {
                        temp4.children.Add(temp3);
                        temp4.children.Add(temp5);
                        temp.children.Add(temp4);
                        
                    }
                    else {
                        error = true;
                    }//error
                    
                    if (begin)
                    {
                        begin = false;
                        first = temp;
                    }
                    else
                    {
                        first.friends.Add(temp);
                    }
                }
                else if(tkns[idx].tknType == "IF")
                {
                    tree temp = new tree(false, "if");
                    idx++;
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }

                    tree temp2 = new tree(false, "");
                    temp2 = exp();
                    
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    tree temp3 = new tree(false, "");
                    temp3 = cmpOP();
                    
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    tree temp4 = new tree(false, "");
                    temp4 = exp();
                    

                    if (match("THEN")) { }
                    else {
                        error = true;
                    }//error

                    tree temp5 = new tree(false, "");
                    temp5 = parse("IF");

                    tree temp6 = new tree(false, "");
                    bool iselse = false;
                    if (tkns[idx].tknType == "ELSE")
                    {
                        idx++;
                        iselse = true;
                        temp6 = parse("IF");
                    }

                    if (match("END")) {
                        temp3.children.Add(temp2);
                        temp3.children.Add(temp4);
                        temp.children.Add(temp3);
                        temp.children.Add(temp5);
                        if (iselse) temp.children.Add(temp6);
                    }
                    else {
                        error = true;
                    }//error
                    if (begin)
                    {
                        begin = false;
                        first = temp;
                    }
                    else
                    {
                        first.friends.Add(temp);
                    }
                }
                else if(tkns[idx].tknType == "IDENTIFIER")
                {
                    tree temp = new tree(false, "");
                    string value = tkns[idx].tknValue;
                    idx++;
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }

                    if (match("ASSIGN"))
                    {
                        value = "assign \n" + value;
                        temp.text = value;
                    }
                    else {
                        error = true;
                    }//error

                    tree temp2 = new tree(false, "");
                    temp2 = exp();
                    if (idx >= input_sz)
                    {
                        error = true;
                        //error
                    }
                    temp.children.Add(temp2);
                    if (tkns[idx].tknType == "SEMICOLON")
                    {
                        idx++;
                        if (t == "IF" && (tkns[idx].tknType != "END" && tkns[idx].tknType != "ELSE")) { }
                        else if (t == "REPEAT" && tkns[idx].tknType != "UNTIL") { }
                        else if (t == "" && idx != input_sz) { }
                        else error = true;
                    }
                    else
                    {
                        if (t == "IF" && (tkns[idx].tknType == "END" || tkns[idx].tknType == "ELSE")) { }
                        else if (t == "REPEAT" && tkns[idx].tknType == "UNTIL") { }
                        else if (t == "" && idx == input_sz) { }
                        else error = true;
                    }

                    if (begin)
                    {
                        begin = false;
                        first = temp;
                        
                    }
                    else
                    {
                        first.friends.Add(temp);
                    }

                }
                else
                {
                    //error
                    if (t == "" && idx == input_sz) break;
                    else if (t == "REPEAT" && tkns[idx].tknType == "UNTIL") break;
                    else if (t == "IF" && (tkns[idx].tknType == "END" || tkns[idx].tknType == "ELSE")) break;
                    else error = true;
                    break;
                }
            }
            return first;
            
        }
       
        public tree cmpOP()
        {
            tree temp = new tree(false, "");
            if (tkns[idx].tknType == "LESSTHAN")
            {
                temp.type = true;
                temp.text = tkns[idx].tknValue;
                idx++;
            }
            else if (tkns[idx].tknType == "EQUAL")
            {
                temp.type = true;
                temp.text = tkns[idx].tknValue;
                idx++;
            }
            else
                error = true;
            return temp;
        }


        public bool match(string token)
        {
            if (idx >= input_sz)
            {
                return false;
                
            }
            else if (tkns[idx].tknType == token)
            {
                idx++;
                return true;
            }
            else
            {
                error = true;
                return false;
                
            }
        }
    }
}
