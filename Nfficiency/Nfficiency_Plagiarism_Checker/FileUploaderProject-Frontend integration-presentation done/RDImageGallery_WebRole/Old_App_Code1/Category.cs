public class Category
{
    private string Pizza_id;
    private string Customer_id;
    private string first_name;
    private string last_name;
    private string street;
    private string city;
    private string state;
    private string zip;
   	public Category()
	{
	}

    public string Pizza_ID
    {
        get
        {
            return Pizza_id;
        }
        set
        {
            Pizza_id = value;
        }
    }

    public string Customer_ID
    {
        get
        {
            return Customer_id;
        }
        set
        {
            Customer_id = value;
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

}// end class