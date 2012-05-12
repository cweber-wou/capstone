using System;

namespace CS430_ASPNET_Role_Records.Old_App_Code1
{
    public class EnrollmentClass
    {

        
            private string user_id;
            private string course_id;
            private string ecourse_name;
           

            //default empty constructor
            public EnrollmentClass()
            {

            }

         public string User_ID
            {
                get
                {
                    return user_id;
                }
                set
                {
                    user_id = value;
                }
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

            public string eCourse_Name
            {
                get
                {
                    return ecourse_name;
                }
                set
                {
                    ecourse_name = value;
                }
            }

            
            }


        }


    


