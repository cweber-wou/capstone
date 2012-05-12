public class Category
{
    
    private string User_id;
    private string password;
    private string first_name;
    private string last_name;
    private string street;
    private string city;
    private string state;
    private string zip;
    private string email;
   	public Category()
	{
	}



    public string User_ID
    {
        get
        {
            return User_id;
        }
        set
        {
            User_id = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }
        set
        {
            password = value;
        }
    }
   

    public string First_Name
    {
        get
        {
            return first_name;
        }
        set
        {
            first_name = value;
        }
    }

    public string Last_Name
    {
        get
        {
            return last_name;
        }
        set
        {
            last_name = value;
        }
    }

         public string Street
         {
        get
        {
            return street;
        }
        set
        {
            street = value;
        }
    }
         public string City
         {
             get
             {
                 return city;
             }
             set
             {
                 city = value;
             }
         }
         public string State
         {
             get
             {
                 return state;
             }
             set
             {
                 state = value;
             }
         }

         public string Zip
         {
             get
             {
                 return zip;
             }
             set
             {
                 zip = value;
             }
         }

         public string Email
         {
             get
             {
                 return email;
             }
             set
             {
                 email = value;
             }
         }

}// end class