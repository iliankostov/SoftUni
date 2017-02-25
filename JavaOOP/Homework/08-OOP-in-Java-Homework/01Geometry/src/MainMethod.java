import models.*;
import models.planeShapes.Circle;
import models.planeShapes.Rectangle;
import models.planeShapes.Triangle;
import models.spaceShapes.Cuboid;
import models.spaceShapes.Sphere;
import models.spaceShapes.SquarePyramid;

import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class MainMethod {
    public static void main(String[] args) {

        Shape triangle = new Triangle(new Vertex2D(0, 1), new Vertex2D(-2, 3), new Vertex2D(4, -5));
        Shape rectangle = new Rectangle(new Vertex2D(3, -5), 5, 20);
        Shape circle = new Circle(new Vertex2D(-2, 4), 5);

        Shape cuboid = new Cuboid(new Vertex3D(7, -4, 2), 1, 2, 2.5);
        Shape sphere = new Sphere(new Vertex3D(-6, 1, -4), 6);
        Shape squarePyramid = new SquarePyramid(new Vertex3D(2, 0, 4), 22, 8);

        Shape[] shapes = new Shape[]{
                triangle,
                rectangle,
                circle,
                cuboid,
                sphere,
                squarePyramid
        };

        for (Shape shape : shapes) {
            System.out.println(shape + "\r\n");
        }

        System.out.println("FILTERED SHAPES BY VOLUME > 40");

        List<SpaceShape> spaceShapes = Arrays.asList(shapes)
                .stream()
                .filter(shape -> shape instanceof SpaceShape)
                .map(shape -> (SpaceShape) shape)
                .filter(volume -> volume.getVolume() > 40)
                .collect(Collectors.toList());

        for (SpaceShape shape : spaceShapes) {
            System.out.println(shape.getShapeName());
            System.out.printf("volume = %.2f", shape.getVolume());
            System.out.println();
        }

        System.out.println();

        System.out.println("FILTERED AND SORTED PLANE SHAPES BY PERIMETER IN ASCENDING ORDER");

        List<PlaneShape> planeShapes = Arrays.asList(shapes)
                .stream()
                .filter(shape -> shape instanceof PlaneShape)
                .map(shape -> (PlaneShape) shape)
                .collect(Collectors.toList());

        Collections.sort(planeShapes, new Comparator<PlaneShape>() {
            public int compare(PlaneShape firstShape, PlaneShape secondShape) {
                return Double.compare(firstShape.getPerimeter(), secondShape.getPerimeter());
            }
        });

        for (PlaneShape shape : planeShapes) {
            System.out.println(shape.getShapeName());
            System.out.printf("perimeter = %.2f", shape.getPerimeter());
            System.out.println();
        }
    }
}