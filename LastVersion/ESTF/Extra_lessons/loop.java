public class Ex3 {
  public static void main(String[] args) {
    System.out.println("Number\t\tSquare");
    System.out.println("-------------------------------");

    // Use while loop
    int number = 10; 
    while (number >= 1) {
      System.out.println(number + "\t\t" + number * number);
      number--;
    }
   
/** Alternatively use for loop    
    for (int number = 10; number >= 1; number--) {
      System.out.println(number + "\t\t" + number*number);
    }
*/
  }
}