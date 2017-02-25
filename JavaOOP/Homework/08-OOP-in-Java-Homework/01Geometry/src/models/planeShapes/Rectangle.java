package models.planeShapes;

import models.PlaneShape;
import models.Vertex2D;

public class Rectangle extends PlaneShape {
    private double width;
    private double height;

    public Rectangle(Vertex2D a, double width, double height) {
        super(new Vertex2D[]{a});
        this.setWidth((width));
        this.setHeight((height));
    }

    public double getWidth() {
        return width;
    }

    private void setWidth(double width) {
        if (width <= 0) {
            throw new IllegalArgumentException();
        }

        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    private void setHeight(double height) {
        if (height <= 0) {
            throw new IllegalArgumentException();
        }

        this.height = height;
    }

    @Override
    public String getShapeName() {
        return "Rectangle";
    }

    @Override
    public double getPerimeter() {
        double perimeter = this.getHeight() * 2 + this.getWidth() * 2;
        return perimeter;
    }

    @Override
    public double getArea() {
        double area = this.getHeight() * this.getWidth();
        return area;
    }

    @Override
    public String toString() {
        StringBuilder rectangleInfo = new StringBuilder();
        rectangleInfo.append(String.format("%s\r\n", this.getShapeName()));
        rectangleInfo.append(String.format("top left point coordinates: %s\r\n", getVertices2D()[0]));
        rectangleInfo.append(String.format("width = %.2f\r\n", this.getWidth()));
        rectangleInfo.append(String.format("height = %.2f\r\n", this.getHeight()));
        rectangleInfo.append(String.format("area = %.2f\r\n", this.getArea()));
        rectangleInfo.append(String.format("perimeter = %.2f", this.getPerimeter()));

        return rectangleInfo.toString();
    }
}