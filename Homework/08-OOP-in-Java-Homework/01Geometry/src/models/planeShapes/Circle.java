package models.planeShapes;

import models.PlaneShape;
import models.Vertex2D;

public class Circle extends PlaneShape {
    private double radius;

    public Circle(Vertex2D center, double radius) {
        super(new Vertex2D[]{center});
        this.setRadius((radius));
    }

    public double getRadius() {
        return radius;
    }

    private void setRadius(double radius) {
        if (radius <= 0) {
            throw new IllegalArgumentException();
        }

        this.radius = radius;
    }

    @Override
    public String getShapeName() {
        return "Circle";
    }

    @Override
    public double getPerimeter() {
        double perimeter = 2 * Math.PI * this.getRadius();
        return perimeter;
    }

    @Override
    public double getArea() {
        double area = Math.PI * this.getRadius() * this.getRadius();
        return area;
    }

    @Override
    public String toString() {
        StringBuilder circleInfo = new StringBuilder();
        circleInfo.append(String.format("%s\r\n", this.getShapeName()));
        circleInfo.append(String.format("radius = %.2f\r\n", this.getRadius()));
        circleInfo.append(String.format("center point coordinates: %s\r\n", getVertices2D()[0]));
        circleInfo.append(String.format("area = %.2f\r\n", this.getArea()));
        circleInfo.append(String.format("perimeter = %.2f", this.getPerimeter()));

        return circleInfo.toString();
    }
}