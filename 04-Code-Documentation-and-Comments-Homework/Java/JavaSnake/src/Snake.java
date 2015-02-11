import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

/**
 * The snake in game.
 */
public class Snake{
    LinkedList<Point> snakeBody = new LinkedList<Point>();
    private Color snakeColor;
    private int velocityX, velocityY;

    public Snake() {
        this.snakeColor = Color.GREEN;
        this.snakeBody.add(new Point(300, 100));
        this.snakeBody.add(new Point(280, 100));
        this.snakeBody.add(new Point(260, 100));
        this.snakeBody.add(new Point(240, 100));
        this.snakeBody.add(new Point(220, 100));
        this.snakeBody.add(new Point(200, 100));
        this.snakeBody.add(new Point(180, 100));
        this.snakeBody.add(new Point(160, 100));
        this.snakeBody.add(new Point(140, 100));
        this.snakeBody.add(new Point(120, 100));

        this.velocityX = 20;
        this.velocityY = 0;
    }

    public void drawSnake(Graphics g) {
        for (Point point : this.snakeBody) {
            point.draw(g, this.snakeColor);
        }
    }

    public void tick() {
        Point head = new Point((this.snakeBody.get(0).getX() + this.velocityX), (this.snakeBody.get(0).getY() + this.velocityY));

        if (head.getX() > Player.WIDTH - 20) {
            Player.gameRunning = false;
        } else if (head.getX() < 0) {
            Player.gameRunning = false;
        } else if (head.getY() < 0) {
            Player.gameRunning = false;
        } else if (head.getY() > Player.HEIGHT - 20) {
            Player.gameRunning = false;
        } else if (Player.apple.getApple().equals(head)) {
            this.snakeBody.add(Player.apple.getApple());
            Player.apple = new Apple(this);
            Player.score += 50;
        } else if (this.snakeBody.contains(head)) {
            Player.gameRunning = false;
            System.out.println("You ate yourself");
        }

        for (int i = this.snakeBody.size()-1; i > 0; i--) {
            this.snakeBody.set(i, new Point(this.snakeBody.get(i-1)));
        }

        this.snakeBody.set(0, head);
    }

    public int getVelocityX() {
        return this.velocityX;
    }

    public void setVelocityX(int velX) {
        this.velocityX = velX;
    }

    public int getVelocityY() {
        return this.velocityY;
    }

    public void setVelocityY(int velY) {
        this.velocityY = velY;
    }
}