import java.util.Scanner;

public class Ex9 {

	/**
	 * 
	 * Modify the program Ex8 by using a do..while loop so that it provides
	 * the user with the option to continue running the program and enter more
	 * inputs
	 * 
	 * @param args
	 */
	public static void main(String[] args) {
		int maxNum; // To hold the upper limit
		int num; // To hold a number
		char choice;

		// Create a Scanner object for keyboard input.
		Scanner keyboard = new Scanner(System.in);
		do {
			// Get a number from the user.
			System.out.print("Enter a positive nonzero number: ");
			maxNum = keyboard.nextInt();

			// Validate the number.
			while (maxNum <= 0) {
				System.out.print("Invalid. Enter a positive nonzero number: ");
				maxNum = keyboard.nextInt();
			}
			int total = 0; // Accumulator
			// Accumulate the sum of the numbers.
			num = 1; // The number series starts at 1.
			while (num <= maxNum) {
				// Add num to total.
				total += num; // same as total = total + num

				// Increment num.
				num++;
			}

			// Display the sum.
			System.out.println("The sum of all the integers "
					+ "from 1 through " + maxNum + " is " + total);

			System.out.println("Do you want to continue? Enter ‘y’ for yes or any other character for no.");
			String input = keyboard.next();
			choice = input.charAt(0);
		} while (choice == 'y');

		System.out.println("End of Program!!!");
	}

}
