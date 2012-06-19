using System;


    public class CourseClass
    {
        private string course_id;
        private string course_name;
        private string course_description;
        private string course_enrollmentkey;
        private string course_owner;
        //default empty constructor
       public CourseClass()
       {
      
       }
    
    public string Course_ID
    {
        get
        {
            return course_id;
        }
        set
        {
            course_id = value;
        }
    }

    public string Course_Name
    {
        get
        {
            return course_name;
        }
        set
        {
            course_name = value;
        }
    }

    public string Course_Description
    {

        get
        {
            return course_description;
        }
        set
        {
            course_description = value;

        }
    }
         public string Course_EnrollmentKey
    {
        
        get
        {
            return course_enrollmentkey;
        }
        set
        {
            course_enrollmentkey = value;
        
        }
    }

         public string Course_Owner
         {

             get
             {
                 return course_owner;
             }
             set
             {
                 course_owner = value;

             }
         }
   
    }


    
