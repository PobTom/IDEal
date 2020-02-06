//********************************************************************
//  FloatCalculations.java        
//********************************************************************

import java.util.Scanner;

public class FloatCalculations
{
   //-----------------------------------------------------------------
   //  Reads two floating point numbers and prints their sum,
   //  difference, and product.
   //-----------------------------------------------------------------
   public static void main (String[] args)
   {
      float num1, num2;
	  Scanner scan = new Scanner (System.in);

      System.out.print ("Enter the first number: ");
      num1 = scan.nextFloat();
      System.out.print ("Enter the second number: ");
      num2 = scan.nextFloat();
      System.out.println ("Their sum is: " + (num1+num2));
      System.out.println ("Their difference is: " + (num1-num2));
      System.out.println ("Their product is: " + (num1*num2));
   }
}
