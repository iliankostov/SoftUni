import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

public class Apple {
    public static Random randomGenerator;
    private Point apple;
    private Color appleColor;

    public Apple(Snake s) {
        apple = createApple(s);
        appleColor = Color.RED;
    }

    /**
     * Create apple with random position.
     * @param s Current snake.
     * @return Return point element of type Point
     */
    private Point createApple(Snake s) {
        randomGenerator = new Random();
        int x = randomGenerator.nextInt(30) * 20;
        int y = randomGenerator.nextInt(30) * 20;
        for (Point snakePoint : s.snakeBody) {
            if (x == snakePoint.getX() || y == snakePoint.getY()) {
                return createApple(s);
            }
        }

        return new Point(x, y);
    }

    /**
     * Draws the apple in window of game
     * @param g object of type Graphics
     */
    public void drawApple(Graphics g) {
        apple.draw(g, appleColor);
    }

    /**
     * Return object apple
     * @return object of type Apple
     */
    public Point getApple() {
        return apple;
    }
}