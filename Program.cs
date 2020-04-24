using System;
using System.Data.SqlClient;
using System.Data;
namespace ERT
{
    class Program
    {
         static void Main(string[] args)
        {
         

       //Console.WriteLine(Calculate());
        const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        
        Console.WriteLine(@"
Если вы уже регистрированый в приложении введите 1:
иначе чтобы регистрироваться введите 2:
Если хотите войти в качестве Admina то выводите 3:
");

          string n=Console.ReadLine();
          T22:int t=0;
        if(n=="1")
           {
            
           while(t!=1)
           {
            con.Open();
            Console.WriteLine("Введите Login:");
            string s=Console.ReadLine();
            Console.WriteLine("Введите Parol:");
            string s1=Console.ReadLine();
            string selectParol="Select * from Registraciya";
            SqlCommand commandText1=new SqlCommand(selectParol,con);
            SqlDataReader reader=commandText1.ExecuteReader();
            while(reader.Read())
            {
                
             if(Convert.ToString(reader.GetValue("login"))==s && Convert.ToString(reader.GetValue("Parol"))==s1)
             {
              t=1;
              Console.WriteLine("Добро пожаловать в свой личный кабинет");
              Console.WriteLine(@"
              выводите 1 чтобы подать заявку 
              выводите 2 если хотите посмотреть свои заявки
              выводите 3 если хотите оплатить кредита");
              string s3=Console.ReadLine();
              
            
            if(s3=="1")
            {
              Zayavka(s);
            } 
            if(s3=="2")
            {
              ProsmotrZayavka(s);
            }

            }
             
            }
            if(t==0)
            {
                Console.WriteLine("Вы неправильно ввели Parol или Login");
            }
            con.Close();
            
           }
           }
           if(n=="2")///////// Здесь заполняем поля для регистрации
           {
            string[] s2=new string[]{"Firstname:","Lastname:","Middlename:","BirthDate:","Date of issue:","Date of expire:","Document №:","Addres:","Marital status","Pol","login","Parol"};
            string[] S= new string[]{};
            string s1="";
            Array.Resize(ref S,12);
            int t1=0,k=0;
            for(int j=0;j<10;j++)
            { 
            t1=0;
            while(t1!=1)
            {
            Console.WriteLine($"Выводите {s2[j]}");
            s1=Console.ReadLine();
            if(string.IsNullOrWhiteSpace(s1))
            {
             Console.WriteLine("Этот поля не должно быть пустым");
            }
            else
            {
              t1=1;
              S[j]=s1;
            }
            }
            }
         
           t1=0;
           while(t1!=1)
           {
            con.Open();
            string selectParol="Select * from Registraciya";
            SqlCommand commandText1=new SqlCommand(selectParol,con);
            SqlDataReader reader=commandText1.ExecuteReader();
            string n13="";
            Console.WriteLine($"Выводите {s2[10]}");
            n13=Console.ReadLine();
            k=0;
            while(reader.Read())
           {
            
            if(Convert.ToString(reader.GetValue("login"))==n13)
            {
             k=1;
             }
           }
           if(k!=1)
           {
            S[10]=n13; 
           t1=1; 
           }
          else
          {
          Console.WriteLine("Такой Login уже существуеть");
          }
          con.Close();
          } 
          Console.WriteLine($"Введите {s2[11]}");
          S[11]=Console.ReadLine();
          Regist Client=new Regist(S[0],S[1],S[2],S[3],S[4],S[5],S[6],S[7],S[8],S[9],S[10],S[11]);
          Client.addRegistr();
          t=0;

///////////////////////////////////////////////////////////////////////////////////////////////////////////


          Console.WriteLine("Для дальнейший регистрации нужно запольнить анкету нажмите любую клавишу");
          Console.ReadKey();
          string[] s8=new string[]{};///////Массив для сохранения данных Анкет;
              string n12;
              Array.Resize(ref s8,10);
              int i=0;
              t=0;
              s8[i]=S[10];
            // con.Close();
              i++;
             
             T20: Console.WriteLine($"Выберите пол");
              Console.WriteLine(@"выводите 1 если муж
выводите 2 если жен");
             
              n12=Console.ReadLine();
              switch(n12)
              {
                case "1":
                s8[i]="муж";
                break;
                case "":
                s8[i]="жен";
                break;
                default:
                {
                  Console.WriteLine("Неверная команда повторите пожалуйста еще раз");
                  goto T20;
                }
              }
            
           
            i++;
            
            
               T10:Console.WriteLine("Выберите Семейное положение");
               Console.WriteLine(@"Выводите 
1 если холост
2 если семянин
3 если вразвоед
4 если вдовец/вдова");
               n12=Console.ReadLine();
               switch(n12)
               {
                   case "1":
                   {
                    s8[i]="холост";
                    break;
                   }
                    case "2":
                   {
                    s8[i]="семеянин";
                    break;
                   }
                    case "3":
                   {
                    s8[i]="вразводе";
                    break;
                   }
                    case "4":
                   {
                    s8[i]="вдовец/вдова";
                    break;
                   }
                   default:
                   {
                    Console.WriteLine("Пожалуйста вывоводите правильно то что требуется ");
                    goto T10;
                   }
               }
          
                
            
               
           
           t=0;
           i++;
           Console.WriteLine("Введите возраст");
           s8[i]=Console.ReadLine();
    
           
          T11: Console.WriteLine(@"Введите 
1 если  вы Гражданин Таджикистана
2 если  вы гражданин другого государство");
            n12=Console.ReadLine();
            i++;
            switch(n12)
            {
              case "1":
                s8[i]="Таджикистан";
                break;
              case "2":
              s8[i]="Таджикистан";
              break;
              default:
              {
                Console.WriteLine("Пожалуйста введите правильно то что требуется");
                goto T11;
              }
               
            }
           
           i++;
           int number;
           
         T:Console.WriteLine("Введите Сумма кредита от общего дохода в %");
           string input=Console.ReadLine();
           if(int.TryParse(input, out number))
           {
             s8[i]=input;
           }
           else
           {
             goto T;
           }

           i++;
        T1:Console.WriteLine("Выводите кредитную историю");
           string input1=Console.ReadLine();
           if(int.TryParse(input1, out number))
           {
             s8[i]=input1;
           }
           else
           {
             goto T1;
           }

           i++;

           T5:Console.WriteLine("Выводите просрока в кредитной истории");
           string input3=Console.ReadLine();
           if(int.TryParse(input3, out number))
           {
             s8[i]=input1;
           }
           else
           {
             Console.WriteLine("Непрвильно ввели число");
             goto T5;
           }

           i++;
         T2:Console.WriteLine(@"Цель Кредита введите
           1 если это бытовая техника
           2 если это ремонт
           3 если телефон
           4 если прочее");
           string n1=Console.ReadLine();
           
           switch(n1)
           {
             case "1":
             {
              s8[i]="бытовая техника";
              break;
             }
             case "2":
             {
              s8[i]="ремонт";
              break;
             }
             case "3":
             {
              s8[i]=" телефон";
              break;
             }
              case "4":
              {
              s8[i]= "прочее";
              break;
              }
              default:
              {
               Console.WriteLine("Не правилно ввели команду повторите еще раз");
               goto T2;
               
              }
           }
            i++;
         T3: Console.WriteLine("Введите срок кредита");
          string input2=Console.ReadLine();
           if(int.TryParse(input1, out number))
           {
             s8[i]=input2;
           }
           else
           {
             goto T3;
           }
           Anceta p1=new Anceta(s8[0],s8[1],s8[2],s8[3],s8[4],s8[5],s8[6],s8[7],s8[8],s8[9]);
           t=0;
           //Calculate(s8[0]);
           p1.addanceta();
           if(Calculate()>11)
           {
           Console.WriteLine("Чтобы подать заявку нужно войти вличный кабинет для этого надо нажать любую клавищу");
           Console.ReadKey();
           n="1";
           goto T22;
           }
           else{
             Console.WriteLine("Извенити что мы не сможем вам заполнить заявку на кредите т.к ваш бали нехватает");
           }
         }
         
        
         
       

        



           string s5="", s6="";
           t=0;
           if(n=="3")
           {
             T1:Console.WriteLine("Введите Login:");
             s5=Console.ReadLine();
             Console.WriteLine("Введите Parol:");
             s6=Console.ReadLine();
             con.Open();
             string selectParol="Select * from Admin1";
             SqlCommand commandText1=new SqlCommand(selectParol,con);
             SqlDataReader reader=commandText1.ExecuteReader();
             
             while(reader.Read())
             {
               if(Convert.ToString(reader.GetValue("login"))==s5 && Convert.ToString(reader.GetValue("Parol"))==s6)
               {
                t=1; 
                Console.WriteLine("Добро пожаловать в личный кабинет Админа");
                Console.WriteLine("Если хотите посмотреть заявок всех клиентов выводите 1");
                Console.WriteLine("Если хотите добавить Админа введите 2");
                n=Console.ReadLine();
                reader.Close();
                con.Close();
                if(n=="1")
                {
                  ProsmotrZayavkaAdmin();
                }
                if(n=="2")/////////////////////
                {
                 

                 Console.WriteLine("Вводите Firstname");
                 string s1=Console.ReadLine();
                 Console.WriteLine("Вводите Lastname");
                 string s2=Console.ReadLine();
                 Console.WriteLine("Вводите Middlename");
                 string s3=Console.ReadLine();
                 T9: Console.WriteLine("Вводите Login");
                 string s4=Console.ReadLine();
                 con.Open();
                 string SelectAdmin1=$"select Login from Admin1";
                 SqlCommand commandText13=new SqlCommand(SelectAdmin1,con);
                 reader=commandText13.ExecuteReader();
                 while(reader.Read())
                {
           
                if(Convert.ToString(reader.GetValue("Login"))==s4)
                {
                Console.WriteLine("Такой Login уже существует");
                con.Close();
                goto T9;
                }
                }
              
                con.Close();
                
                Console.WriteLine("Вводите Parol");
                string s51=Console.ReadLine();
                
                Admin1 p=new Admin1(s1,s2,s3,s4,s51);
                p.addAdmin();
                goto T12;
                }

              }
            }
            T12:

            
             if(t==1)
             {
              
             }
             else 
             {
              Console.WriteLine("Не правильный Parol или Login");
              reader.Close();
              con.Close();
              goto T1;
             }
             
           }
           
           
         
        
        

        }

        class Admin1
        {
          public String Firstname;
          public string Lastname;
          public string MiddleName;
          public string Login;
          public string Parol;
          public Admin1(string Firstname,string Lastname,string MiddleName,string Login,string Parol)
          {
            this.Firstname=Firstname;
            this.Lastname=Lastname;
            this.MiddleName=MiddleName;
            this.Login=Login;
            this.Parol=Parol;
          }
          public void addAdmin()
          {
            
          const string constring=@"Data source=localhost;initial catalog=Client; Integrated Security=True";
          SqlConnection con = new SqlConnection(constring);   
          con.Open(); 
          string InsertZayavka=$"insert into Admin1([Firstname],[LastName],[Middlename],[Login],[Parol]) Values('{Firstname}','{Lastname}','{MiddleName}','{Login}','{Parol}')";
          SqlCommand commandText12=new SqlCommand(InsertZayavka,con);
          var result = commandText12.ExecuteNonQuery(); 
          con.Close();
          }
        }

        class Regist
        {
          public string Firstname;
          public string Lastname;
          public string Middlename;
          public string BirthDate;
          public string Dataofissue;
          public string Dataofexpire;
          public string DocumentN;
          public string Addres;
          public string Maritalstatus;
          public string Pol;
          public string Login;
          public string Parol;
          public Regist(string Firstname,string Lastname,string Middlename,string BirthDate, string Dataofissue,string Dataofexpire,string DocumentN,string Addres, string Maritalstatus,string Pol,string Login,string Parol)
          {
            this.Firstname=Firstname;
            this.Lastname=Lastname;
            this.Middlename=Middlename;
            this.BirthDate=BirthDate;
            this.Dataofexpire=Dataofissue;
            this.Dataofexpire=Dataofexpire;
            this.DocumentN=DocumentN;
            this.Addres=Addres;
            this.Maritalstatus=Maritalstatus;
            this.Pol=Pol;
            this.Login=Login;
            this.Parol=Parol;

          }
        public void addRegistr()
        {
        int t=0;
        const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        con.Open();

        string  insertSql=$"insert into Registraciya([Firstname],[Lastname],[Middlename],[BirthDate],[Date of issue],[Date of expire],[Docunent №],[Address],[Marital status],[Pol],[login],[Parol]) Values('{Firstname}','{Lastname}','{Middlename}','{BirthDate}','{Dataofissue}','{Dataofexpire}','{DocumentN}','{Addres}','{Maritalstatus}','{Pol}','{Login}','{Parol}')";
        SqlCommand commandText=new SqlCommand(insertSql,con);
        var result = commandText.ExecuteNonQuery(); 
        con.Close();
        Console.WriteLine("Вы успешно регистрировались");
        
        }
        }



       

        


        class Anceta
        {
          public string DocumentN;
          public string Pol;
          public string Semeynoepolozh;
          public string Voz;
          public string Grazhdanstvo;
          public string summak;
          public string kreditistory;
          public string prosroka;
          public string celk;
          public string srokk;

        public Anceta(string DocumentN,string Pol,string Semeynoepolozh,string Voz,string Grazhdanstvo,string summak,string kreditistory,string prosroka,string celk,string srokk)
        {
         this.DocumentN=DocumentN;
         this.Pol=Pol;
         this.Semeynoepolozh=Semeynoepolozh;
         this.Voz=Voz;
         this.Grazhdanstvo=Grazhdanstvo;
         this.summak=summak;
         this.kreditistory=kreditistory;
         this.prosroka=prosroka;
         this.celk=celk;
         this.srokk=srokk;
        }
        public void addanceta()
        {
         const string constring=@"Data source=localhost;initial catalog=Client; Integrated Security=True";
         SqlConnection con = new SqlConnection(constring);
         con.Open();
         string InsertAncet=$"insert into Anceta([серийный номер],[пол],[семейное положение],[возраст],[гражданство],[сумма кредита от общего дохода],[кредитная история],[просрока в кредитной истории],[цель кредита],[срок кредита]) Values('{DocumentN}','{Pol}','{Semeynoepolozh}','{Voz}','{Grazhdanstvo}','{summak}','{kreditistory}','{prosroka}','{celk}','{srokk}')";
         SqlCommand commandText12=new SqlCommand(InsertAncet,con);
         var result = commandText12.ExecuteNonQuery(); 
         con.Close();  
         Console.WriteLine("Успешно заполнили анкету");
        }
        }
       
     static void Zayavka(string s)
     {
      
      T6:Console.WriteLine(@"Укажите цель, вводите 
      1 если это бытовая техника
      2 если это ремонт
      3 если это телефон
      4 если это прочее");
      string cel=Console.ReadLine(),cel1=" ";
      switch(cel)
      {
        case "1":
        cel1="бытовая техника";
        break;
        case "2":
        cel1="ремонт";
        break;
        case "3":
        cel1="телефон";
        break;
        case "4":
        cel1="прочее";
        break;
        default:
        {
          Console.WriteLine("Пожалуйста введите правильно то что требуется");
          goto T6;
        }
      }


      T7:Console.WriteLine("Укажите Cумму кредита");
      string sum=Console.ReadLine();
      int number; 
      if(string.IsNullOrWhiteSpace(sum)==true || int.TryParse(sum, out number)==false)
      {
        Console.WriteLine("Этот поля не должно быть пустим и не можеть быть строкам");
        goto T7;
      }
      

       
    T8:Console.WriteLine("Укажите срок кредита");
      string srok=Console.ReadLine();
      if(string.IsNullOrWhiteSpace(srok)==true || int.TryParse(sum, out number)==false)
      {
        Console.WriteLine("Этот поля не должно быть пустим");
        goto T8;
      }
      
      int srok1=Convert.ToInt32(srok),sum1=Convert.ToInt32(sum);
 
      const string constring=@"Data source=localhost;initial catalog=Client; Integrated Security=True";
      SqlConnection con = new SqlConnection(constring);
      con.Open();
      string InsertZayavka=$"insert into Zayavka Values('{s}','{sum1}','{srok1}','{cel1}')";
      SqlCommand commandText12=new SqlCommand(InsertZayavka,con);
      var result = commandText12.ExecuteNonQuery(); 
      con.Close();
      }


      static void ProsmotrZayavka(string s)
      {

      const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        con.Open();
        string selectSql = $"Select * from Zayavka where [серийный номер]={s}";
        SqlCommand commandText = new SqlCommand(selectSql, con);
        SqlDataReader reader = commandText.ExecuteReader();
        while (reader.Read())
        {
System.Console.WriteLine($@"ID: {reader.GetValue("id")},
            Firstname: {reader.GetValue("серийный номер")},
            LastName: {reader.GetValue("сумма кредита")},
            MiddleName: {reader.GetValue("срок кредита")},
            BirthDate: {reader.GetValue("цель кредита")}, 
            ");
        }
        reader.Close();
        con.Close();
        
        }
        
      static void ProsmotrZayavkaAdmin()
      {
      const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        con.Open();
        string selectSql = $"Select * from Zayavka";
        SqlCommand commandText = new SqlCommand(selectSql, con);
        SqlDataReader reader = commandText.ExecuteReader();
        while (reader.Read())
        {
System.Console.WriteLine($@"ID: {reader.GetValue("id")},
            Firstname: {reader.GetValue("серийный номер")},
            LastName: {reader.GetValue("сумма кредита")},
            MiddleName: {reader.GetValue("срок кредита")},
            BirthDate: {reader.GetValue("цель кредита")}, 
            ");
        }
        reader.Close();
        con.Close();
       }
       
       static int Calculate()
       {
        int k=0;
        const string constring=@"Data source=localhost; initial catalog=Client; Integrated Security=True";
        SqlConnection con = new SqlConnection(constring);
        con.Open();
        string selectSql = $"Select * from Anceta where [серийный номер]='904505050'";
        SqlCommand commandText = new SqlCommand(selectSql, con);
        SqlDataReader reader = commandText.ExecuteReader();
        while(reader.Read())
        {
          if(Convert.ToString(reader.GetValue("пол"))=="муж")
          {
           k=k+1;
          }
          else{
            k=k+2;
          }

          if(Convert.ToString(reader.GetValue("семейное положение"))=="холость" || Convert.ToString(reader.GetValue("семейное положение"))=="в разводе" )
          {
           k=k+1;
          }
          else{
            k=k+2;
          }

          if((Convert.ToInt32(reader.GetValue("возраст"))>=26 && Convert.ToInt32(reader.GetValue("возраст"))<=35) || ((Convert.ToInt32(reader.GetValue("возраст"))>=63)))
          {
           k=k+1;
          }
          else{
            if((Convert.ToInt32(reader.GetValue("возраст"))<=25))
            {
            k=k+0;
            }
            else
            {
              if((Convert.ToInt32(reader.GetValue("возраст"))>=36 && Convert.ToInt32(reader.GetValue("возраст"))<=62))
              {
                k=k+2;
              }
            }
          }

          if(Convert.ToString(reader.GetValue("гражданство"))=="Таджикистан")
          {
            k=k+1;
          }

          if(Convert.ToInt32(reader.GetValue("сумма кредита от общего дохода"))<80)
          {
            k=k+4;
          }

          if(Convert.ToInt32(reader.GetValue("сумма кредита от общего дохода"))>=80 && Convert.ToInt32(reader.GetValue("сумма кредита от общего дохода"))<150 )
          {
            k=k+3;
          }
          
          if(Convert.ToInt32(reader.GetValue("сумма кредита от общего дохода"))>=150 && Convert.ToInt32(reader.GetValue("сумма кредита от общего дохода"))<250 )
          {
            k=k+2;
          }

          if(Convert.ToInt32(reader.GetValue("сумма кредита от общего дохода"))>=250)
          {
            k=k+1;
          }
         
          if(Convert.ToInt32(reader.GetValue("кредитная история"))>3)
          {
            k=k+2;
          }

          if(Convert.ToInt32(reader.GetValue("кредитная история"))==1 || Convert.ToInt32(reader.GetValue("кредитная история"))==2)
          {
            k=k+1;
          }

          if(Convert.ToInt32(reader.GetValue("кредитная история"))==0)
          {
            k=k-1;
          }

          if(Convert.ToInt32(reader.GetValue("просрока в кредитной истории"))>7)
          {
            k=k-3;
          }

          if(Convert.ToInt32(reader.GetValue("просрока в кредитной истории"))>=5 && Convert.ToInt32(reader.GetValue("просрока в кредитной истории"))<=7 )
          {
            k=k-2;
          }

          if(Convert.ToInt32(reader.GetValue("просрока в кредитной истории"))==4)
          {
            k=k-1;
          }
          
          if(Convert.ToInt32(reader.GetValue("просрока в кредитной истории"))<=3)
          {
            k=k-0;
          }

          if(Convert.ToString(reader.GetValue("цель кредита"))=="бытовая техника")
          {
            k=k+2;
          }
          
          if(Convert.ToString(reader.GetValue("цель кредита"))=="ремонт")
          {
            k=k+1;
          }

          if(Convert.ToString(reader.GetValue("цель кредита"))=="телефон")
          {
            k=k+0;
          }

          if(Convert.ToString(reader.GetValue("цель кредита"))=="прочее")
          {
            k=k-1;
          }

          if(Convert.ToInt32(reader.GetValue("срок кредита"))>=12 || Convert.ToInt32(reader.GetValue("срок кредита"))<12)
          {
            k=k+1;
          }
          



        }
        reader.Close();
        con.Close();
        return k;
       }
       
    }
}
