import java.util.Scanner;

public class Ex4 {

	/**
	 * A program that inputs a series of positive integers from the user and
	 * then displays the sum of the positive integers. The user has to enter -1
	 * to end the input series. Use a while loop
	 * 
	 * @param args
	 */
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		System.out.println("Enter a series of positive integers. Enter -1 to end series.");
		int num = scan.nextInt();
		int sum = 0;
		while (num != -1) {
			sum = sum + num;
			num = scan.nextInt();
		}
		System.out.println("Sum of positive integers is: " + sum);
	}

}
