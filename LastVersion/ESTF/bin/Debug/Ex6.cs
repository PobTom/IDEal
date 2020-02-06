import java.util.Scanner;


public class Ex6 {

    /**
     *
     * A program that uses a while loop to verify that the user enters a positive integer value
     * @param args
     */
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int num;
        do {
            System.out.println("Enter a positive integer");
            num = scan.nextInt();
            System.out.println("Invalid input...Please enter a positive integer");
            num = scan.nextInt();
        } while (num < 0);
        System.out.println("Thank You.. That is a valid input.");
    }

}
