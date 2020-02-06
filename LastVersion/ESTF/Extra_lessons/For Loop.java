import java.util.Scanner;

public class Ex1 {

	/**
	 * A program that asks your name and prints Hello "yourname” five times
	 * 
	 * @param args
	 */
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		System.out.println("Enter your name");
		String name = scan.nextLine();
		for (int i = 0; i < 5; i++) {
			System.out.println("Hello " + name);
		}

	}

}
