package models;

public class Vertex2D {
    private double x;
    private double y;

    public Vertex2D(double x, double y) {
        this.setX(x);
        this.setY(y);
    }

    public double getX() {
        return x;
    }

    private void setX(double x) {
        this.x = x;
    }

    public double getY() {
        return y;
    }

    private void setY(double y) {
        this.y = y;
    }

    @Override
    public String toString() {
        StringBuilder vertexInfo = new StringBuilder();
        vertexInfo.append(String.format("(%.2f, %.2f)", this.getX(), this.getY()));
        return  vertexInfo.toString();
    }
}