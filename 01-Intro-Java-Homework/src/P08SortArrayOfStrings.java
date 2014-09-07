
import java.util.Scanner;

public class P08SortArrayOfStrings {

	public static void main(String[] args) {
		
		Scanner scanner = new Scanner(System.in);		
		int number;	
		System.out.print("Enter number: ");
		number = scanner.nextInt();
		String[] strArray = new String[number];
		for (int i = 0; i < number; i++) {
			System.out.print("Enter string" + (i+1) + ":");
			strArray[i] = scanner.next();					
		}
		scanner.close();		
		sortStringExchange (strArray);
		
		for (int i = 0; i < strArray.length; i++) {
			System.out.println(strArray[i]);
		}
		
	}
	
	public static void sortStringExchange( String  x [ ] )
    {
          int i, j;
          String temp;

          for ( i = 0;  i < x.length - 1;  i++ )
          {
              for ( j = i + 1;  j < x.length;  j++ )
              {  
                       if ( x [ i ].compareToIgnoreCase( x [ j ] ) > 0 )
                        {                                             // ascending sort
                                    temp = x [ i ];
                                    x [ i ] = x [ j ];    // swapping
                                    x [ j ] = temp; 
                                    
                         } 
                 } 
           } 
    }
	
}
