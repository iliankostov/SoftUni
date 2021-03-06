import java.awt.Color;
import java.awt.Graphics;

/**
 *  One element of the snake.
 */
public class Point {
    private int x, y;
    private final int width = 20;
    private final int height = 20;

    /**
     * Clones element of the snake.
     * @param p Element of the snake.
     */
    public Point(Point p){
        this(p.x, p.y);
    }

    /**
     * Creates new element of the snake on position X and Y.
     * @param x X coordinate
     * @param y Y coordinate
     */
    public Point(int x, int y){
        this.x = x;
        this.y = y;
    }

    /**
     * Get X coordinate.
     * @return X coordinate.
     */
    public int getX() {
        return this.x;
    }

    /**
     * Set X coordinate.
     * @param X coordinate.
     */
    public void setX(int x) {
        this.x = x;
    }

    /**
     * Get Y coordinate
     * @return Y coordinate
     */
    public int getY() {
        return this.y;
    }

    /**
     * Set Y coordinate
     * @param y y coordinate
     */
    public void setY(int y) {
        this.y = y;
    }

    /**
     * Draws snske's element in g whit color cVqt.
     * @param g Object of class Graphics.
     * @param cVqt Color of snake's element of class Color.
     */
    public void draw(Graphics g, Color cVqt) {
        g.setColor(Color.BLACK);
        g.fillRect(this.x, this.y, this.width, this.height);
        g.setColor(cVqt);
        g.fillRect(this.x + 1, this.y + 1, this.width - 2, this.height - 2);
    }

    public String toString() {
        return "[x = " + this.x + ", y = " + this.y + "]";
    }

    public boolean equals(Object object) {
        if (object instanceof Point) {
            Point point = (Point)object;
            return (this.x == point.x) && (this.y == point.y);
        }

        return false;
    }
}