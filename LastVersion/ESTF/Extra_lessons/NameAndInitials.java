/**
  Name and Initials
*/

public class NameAndInitials
{
   public static void main(String[] args)
   {
      String firstName = "Herbert";    // First name
      String lastName = "Dorfmann";    // Last name
             
      char firstInitial;               // To hold the first initial
      char lastInitial;                // To hold the last initial
      
      // Get the initials.
      firstInitial = firstName.charAt(0);
      lastInitial = lastName.charAt(0);
      
      // Display the contents of the variables.
      System.out.println("Name: " + firstName +
                         lastName);
      System.out.println("Initials: " + firstInitial +
                         lastInitial);
   }
}
