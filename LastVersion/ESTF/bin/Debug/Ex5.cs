import java.util.Scanner;

public class Ex5 {

    /**
     * A program that reads the width and generates a corresponding square of
     * *.
     * 
     * @param args
     */
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out
                .println("Enter the width of the square you want to generate");
        int num = scan.nextInt();
        for (int i = 0; i < num; i++) {
            for (int j = 0; j < num; j++) {
                System.out.print("*");
            }
            System.out.println();
        }

    }

}
