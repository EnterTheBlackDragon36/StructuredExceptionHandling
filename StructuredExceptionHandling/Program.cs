using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuredExceptionHandling
{
    class Program
    {
        class Car
        {
            // Constant for maximum speed.
            public const int MaxSpeed = 100;

            // Car Properties
            public int CurrentSpeed { get; set; }
            public string PetName { get; set; }

            // Is the car still operational?
            private bool carIsDead;

            // A car has-a radio.
            private Radio theMusicBox = new Radio();

            // Constructors
            public Car() { }
            public Car(string name, int speed)
            {
                CurrentSpeed = speed;
                PetName = name;
            }

            public void CrankTunes(bool state)
            {
                //Delegate request to inner object.
                theMusicBox.TurnOn(state);
            }

            // See if Car has overheated.
            #region First Accelerate Method
            //public void Accelerate(int delta)
            //{
            //    if (carIsDead)
            //        Console.WriteLine("{0} is out of order...", PetName);
            //    else
            //    {
            //        CurrentSpeed += delta;
            //        if (CurrentSpeed > MaxSpeed)
            //        {
            //            Console.WriteLine("{0} has overheated!", PetName);
            //            CurrentSpeed = 0;
            //            carIsDead = true;
            //        }
            //        else
            //            Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            //    }
            //}
            #endregion

            #region Second Accelerate Method HelpLink Property
            //public void Accelerate(int delta)
            //{
            //    if (carIsDead)
            //        Console.WriteLine("{0} is out of order...", PetName);
            //    else
            //    {
            //        CurrentSpeed += delta;
            //        if (CurrentSpeed >= MaxSpeed)
            //        {
            //            carIsDead = true;
            //            CurrentSpeed = 0;

            //            // We need to call the HelpLink property, thus we need
            //            // to create local variable before throwing the Exception object.
            //            Exception ex = new Exception(string.Format("{0} has overheated!", PetName));
            //            ex.HelpLink = "http://www.CarsRUs.com";

            //            // Stuff in custom data regarding the error.
            //            ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
            //            ex.Data.Add("Cause", "You have a lead foot.");
            //            throw ex;
            //        }
            //        else
            //            Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            //    }
            //}
            #endregion

            #region Third Accelerate Method Data Property
            //public void Accelerate(int delta)
            //{
            //    if (carIsDead)
            //        Console.WriteLine("{0} is out of order...", PetName);
            //    else
            //    {
            //        CurrentSpeed += delta;
            //        if (CurrentSpeed >= MaxSpeed)
            //        {
            //            carIsDead = true;
            //            CurrentSpeed = 0;

            //            // We need to call the HelpLink property, thus we need
            //            // to create a local variable before throwing the Exception object.
            //            Exception ex = new Exception(string.Format("{0} has overheated!", PetName));
            //            ex.HelpLink = "http://www.CarsRUs.com";

            //            // Stuff in custom data regarding the error.
            //            ex.Data.Add("TimeStamp", string.Format("The car exploded at {0}", DateTime.Now));
            //            ex.Data.Add("Cause", "You have a lead foot.");
            //            throw ex;
            //        }
            //        else
            //            Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            //    }
            //}
            #endregion

            #region Fourth Accelerate Method Custom Exception Property
            //public void Accelerate(int delta)
            //{
            //    if (carIsDead)
            //        Console.WriteLine("{0} is out of order...", PetName);
            //    else
            //    {
            //        CurrentSpeed += delta;
            //        if (CurrentSpeed >= MaxSpeed)
            //        {
            //            carIsDead = true;
            //            CurrentSpeed = 0;

            //            CarIsDeadException ex = new CarIsDeadException (string.Format("{0} has overheated!", PetName),
            //            "You have a lead foot", DateTime.Now);
            //            ex.HelpLink = "http://www.CarsRUs.com";
            //            throw ex;
                        
            //        }
            //        else
            //            Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
            //    }
            //}
            #endregion

            #region Fifth Accelerate Method Processing Multiple Exceptions
            public void Accelerate(int delta)
            {
                if (delta < 0)
                    throw new ArgumentOutOfRangeException("delta", "Speed must be greater than zero!");

                if (carIsDead)
                    Console.WriteLine("{0} is out of order...", PetName);
                else
                {
                    CurrentSpeed += delta;
                    if (CurrentSpeed >= MaxSpeed)
                    {
                        carIsDead = true;
                        CurrentSpeed = 0;

                        CarIsDeadException ex = new CarIsDeadException(string.Format("{0} has overheated!", PetName),
                        "You have a lead foot", DateTime.Now);
                        ex.HelpLink = "http://www.CarsRUs.com";
                        throw ex;

                    }
                    else
                        Console.WriteLine("=> CurrentSpeed = {0}", CurrentSpeed);
                }
            }


            #endregion


            static void Main(string[] args)
            {
                #region First Handling Sample
                //Console.WriteLine("***** Simple Exception Example *****");
                //Console.WriteLine("=> Creating a car and stepping on it!");
                //Car myCar = new Car("Zippy", 20);
                //myCar.CrankTunes(true);

                //for (int i = 0; i < 10; i++)
                //    myCar.Accelerate(10);
                //Console.ReadLine();
                #endregion

                #region Second Handling Sample
                //Console.WriteLine("***** Simple Exception Example *****");
                //Console.WriteLine("=> Creating a car and stepping on it!");
                //Car myCar = new Car("Zippy", 20);
                //myCar.CrankTunes(true);

                //// Speed up past the car's max speed to
                //// trigger the exception
                //try
                //{
                //    for (int i = 0; i < 10; i++)
                //        myCar.Accelerate(10);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("\n*** Error! ***");
                //    Console.WriteLine("Method: {0}", e.TargetSite);
                //    Console.WriteLine("Message: {0}", e.Message);
                //    Console.WriteLine("Source: {0}", e.Source);
                //}

                //// The error has been handled, processing continues with the next statement.
                //Console.WriteLine("\n***** Out of exception logic *****");
                //Console.ReadLine();
                #endregion

                #region Third Handling Sample
                //Console.WriteLine("***** Simple Exception Example *****");
                //Console.WriteLine("=> Creating a car and stepping on it!");
                //Car myCar = new Car("Zippy", 20);
                //myCar.CrankTunes(true);

                //// Speed up past the car's max speed to
                //// trigger the exception
                //try
                //{
                //    for (int i = 0; i < 10; i++)
                //        myCar.Accelerate(10);
                //}
                //catch(Exception e)
                //{
                //  Console.WriteLine("\n*** Error! ***");
                //  Console.WriteLine("Member name: {0}", e.TargetSite);
                //  Console.WriteLine("Class defining member: {0}",
                //    e.TargetSite.DeclaringType);
                //  Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);
                //  Console.WriteLine("Message: {0}", e.Message);
                //  Console.WriteLine("Source: {0}", e.Source);
                //}
                //Console.WriteLine("\n***** Out of exception logic *****");
                //Console.ReadLine();
                //}
                #endregion

                #region Fourth Handling Sample
                //Console.WriteLine("***** Simple Exception Example *****");
                //Console.WriteLine("=> Creating a car and stepping on it!");
                //Car myCar = new Car("Zippy", 20);
                //myCar.CrankTunes(true);

                //// Speed up past the car's max speed to
                //// trigger the exception
                //try
                //{
                //    for (int i = 0; i < 10; i++)
                //        myCar.Accelerate(10);
                //}

                //catch (Exception e)
                //{
                //    Console.WriteLine("\n*** Error! ***");
                //    Console.WriteLine("Member name: {0}", e.TargetSite);
                //    Console.WriteLine("Class defining member: {0}", e.TargetSite.DeclaringType);
                //    Console.WriteLine("Member type: {0}", e.TargetSite.MemberType);
                //    Console.WriteLine("Message: {0}", e.Message);
                //    Console.WriteLine("Source: {0}", e.Source);

                //    //By default, the data field is empty, so check for null.
                //    Console.WriteLine("\n-> Custom Data:");

                //    if (e.Data != null)
                //    {
                //        foreach (DictionaryEntry de in e.Data)
                //            Console.WriteLine("-> {0}: {1}", de.Key, de.Value);
                //    }
                //}
                //Console.ReadLine();
                #endregion

                #region Fifth Handling Sample Custom Exception
                //Console.WriteLine("***** Fun with Custom Exceptions *****\n");
                //Car myCar = new Car("Rusty", 90);

                //try
                //{
                //    // Trip Exception.
                //    myCar.Accelerate(50);
                //}
                //catch (CarIsDeadException e)
                //{
                //    Console.WriteLine(e.Message);
                //    Console.WriteLine(e.ErrorTimeStamp);
                //    Console.WriteLine(e.CauseOfError);
                //}
                //Console.ReadLine();
                #endregion

                #region Sixth Sample Processing Multiple Exceptions
                //Console.WriteLine("***** Handling Multiple Exceptions *****\n");
                //Car myCar = new Car("Rusty", 90);
                //try
                //{
                //    // Trip Arg out of range exception
                //    myCar.Accelerate(-10);
                //}
                //catch (CarIsDeadException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                //catch (ArgumentOutOfRangeException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                //Console.ReadLine();
                #endregion

                #region Seventh Sample Handling Multiple Exceptions 
                //Console.WriteLine("***** Handling Multiple Exceptions *****\n");
                //Car myCar = new Car("Rusty", 90);
                //try
                //{
                //    // Trigger an argument out of range exception.
                //    myCar.Accelerate(-10);
                //}
                //catch (CarIsDeadException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                //catch (ArgumentOutOfRangeException e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                //// This will catch any other exception
                //// beyond CarIsDeadException or 
                //// ArgumentOutOfRangeException.
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                //}
                //Console.ReadLine();
                #endregion

                #region Eight Sample Generic Catch
                //Console.WriteLine("***** Handling Multiple Exceptions *****\n");
                //Car myCar = new Car("Rusty", 90);
                //  try
                //  {
                //    myCar.Accelerate(90);
                //  }
                //  catch (CarIsDeadException e)
                //  {
                //      // Attempt to open a file named carErrors.txt on the C drive.
                //      FileStream fs = File.Open(@"C:\carErrors.txt", FileMode.Create, FileAccess.ReadWrite);
                      
                //  }
                //Console.ReadLine();
                #endregion

                #region Ninth Sample Finally Block
                Console.WriteLine("***** Handling Multiple Exceptions *****\n");
                Car myCar = new Car("Rusty", 90);
                myCar.CrankTunes(true);

                try
                {
                    myCar.Accelerate(90);
                }
                catch (CarIsDeadException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    // This will always occur. Exception or not.
                    myCar.CrankTunes(false);
                }
                Console.ReadLine();
                #endregion

            }


            class Radio
            {
                public void TurnOn(bool on)
                {
                    if (on)
                        Console.WriteLine("Jamming...");
                    else
                        Console.WriteLine("Quiet time...");
                }
            }



        }
    }
}
