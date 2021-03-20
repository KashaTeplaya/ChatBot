using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ChatBot
{
    class ChatBot
    {
        string q,
        path, userAnswer;
        List<string> sempls = new List<string>();
        bool knowAnswer = true;

        public event Action<string> GetStr;
        public ChatBot(string path) {
            this.path = path ;
            try
            {
                sempls.AddRange(File.ReadAllLines(path));
            }
            catch { }
         
            GetStr += ChatBot_GetStr;
            GetStr("Ваш вопрос");
        } 
        private string Answer(string qw)
        {
            string tr = ")(:^^=", ans = String.Empty;
            qw = qw.ToLower();
             qw = Trim(qw,tr.ToCharArray());
            for (int i = 0; i < sempls.Count; i+=2)
            {
                if (qw == sempls[i]) {
                    ans = sempls[i + 1];
                    break;
                }
            }
            return ans;
        }
        private void Teach() 
        {
            q = q.ToLower();
            sempls.Add(q);
            sempls.Add(userAnswer);
            File.WriteAllLines(path, sempls.ToArray());
        }
        public void Ans(string qw) 
        {
            if (knowAnswer)
            {
                q = qw;
                string ans = Answer(qw);
                if (ans == string.Empty)
                {
                    knowAnswer = false;
                    GetStr("Не знаю даже что ответить, научи:");
                }
                else GetStr("Ответ бота:" + ans + "\n\n Ваш вопрос: ");
            }
            else { knowAnswer = true;
                userAnswer = qw;
                Teach();
                GetStr("\nЧто еще хотите узнать?:");
            }
        }
        public void ChatBot_GetStr(string obj) { }
        string Trim(string str, char[] chars) 
        {
            string strA = str;
            for (int i = 0; i < chars.Length; i++) 
            {
                strA = strA.Replace(char.ToString(chars[i]), "");
            }
            return strA;
        }
    }
        
}
