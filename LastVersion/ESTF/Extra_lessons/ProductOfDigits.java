import java.util.Scanner;

public class ProductOfDigits {
	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		// Read in an integer
		System.out.print("Enter an integer between 100 and 999: ");
		int number = input.nextInt();

		// Find all digits in number
		int lastDigit = number % 10;
		int remainingNumber = number / 10;
		int secondLastDigit = remainingNumber % 10;
		remainingNumber = remainingNumber / 10;
		int thirdLastDigit = remainingNumber % 10;

		// Obtain the product of all digits
		int product = lastDigit * secondLastDigit * thirdLastDigit;

		// Display results
		System.out.println("The product of the digits is " + product + ".");
	}
}
