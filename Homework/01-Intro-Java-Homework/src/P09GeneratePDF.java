
public class P09GeneratePDF {

	public static void main(String[] args) {
		
		String[] cards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A" };
        int[] suits = { 9824, 9829, 9830, 9827 };
                
        for (String card: cards)
        {            
            for (int suit: suits)
            {
                switch (suit)
                {
                    case 9824:
                        System.out.printf("%s%s ", card, (char)suit);
                        break;
                    case 9829:
                        System.out.printf("%s%s ", card, (char)suit);
                        break;
                    case 9830:
                        System.out.printf("%s%s ", card, (char)suit);
                        break;
                    case 9827:
                        System.out.printf("%s%s \n", card, (char)suit);
                        break;
                    default:
                        System.out.println();
                        break;
                }               
            }
        }
	}	
}
