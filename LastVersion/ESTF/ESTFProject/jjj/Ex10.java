import java.util.Scanner;

public class Ex10 {

    /**
     * A program that reads the width and generates a corresponding triangle of
     * *.
     * 
     * @param args
     */
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        System.out
                .println("Enter the width of the triangle you want to generate");
        int num = scan.nextInt();
        for (int i = 0; i < num; i++) {
            for (int j = 0; j < (i+1); j++) {
                System.out.print("*");
            }
            System.out.println();
        }

    }

}
