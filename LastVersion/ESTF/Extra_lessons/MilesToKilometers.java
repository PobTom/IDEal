//********************************************************************
//  MilesToKilometers.java       
//********************************************************************

import java.util.Scanner;

public class MilesToKilometers
{
   //-----------------------------------------------------------------
   //  Converts miles into kilometers. The value for miles is read
   //  from the user.
   //-----------------------------------------------------------------
   public static void main (String[] args)
   {
      double miles, kilometers;

	  Scanner scan = new Scanner(System.in);

      System.out.print ("Enter the distance in miles: ");
      miles = scan.nextDouble();

      kilometers = 1.60935 * miles;

      System.out.println ("That distance in kilometers is: " +
                          kilometers);
   }
}
