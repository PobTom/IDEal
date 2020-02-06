import java.util.*;
public class OrderPizza
{
public static void main (String[] args)
{
      Scanner input = new Scanner(System.in);  // declare a Scanner object

      //some constants
      final double PRICE_OF_PIZZA = 12.00;
      final double PRICE_OF_TOPPING = 1.50;
      final double TAX_RATE = .05;

      int numPizza, numTopping;
      double cost= 0.0;

      //determine the number of pizza and adjust the cost
      System.out.print("Enter the number of pizzas: ");
      numPizza = input.nextInt();
      cost = cost + numPizza* PRICE_OF_PIZZA;

      //determine the number of toppings and adjust the cost
      System.out.print("Enter the total number of toppings: ");
      numTopping = input.nextInt();
      cost = cost + numTopping* PRICE_OF_TOPPING;

      //add tax
      cost = cost + TAX_RATE*cost;

      System.out.println();
      System.out.println("Receipt: ");
      System.out.println("Number of Pizzas:   "+numPizza);
      System.out.println("Number of Toppings: "+numTopping);
      System.out.println("Cost (incl tax):   £"+cost);
   }
}
