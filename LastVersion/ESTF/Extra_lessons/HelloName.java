import java.util.Scanner;

public class HelloName {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		System.out.println("Enter your name");
		String name = scan.nextLine();
		System.out.print("Hello "+ name);

	}

}
