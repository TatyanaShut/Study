package sample;

import javafx.beans.binding.Bindings;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.shape.Circle;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class CircleBox {

    public static void display() {
        Stage stage = new Stage();
        stage.initModality(Modality.APPLICATION_MODAL);
        stage.setTitle("Рисуем круг по центру");

        Circle circle = new Circle();
        Group root = new Group(circle);

        Scene scene = new Scene(root,100,100);

        circle.centerXProperty().bind(scene.widthProperty().divide(2));
        circle.centerYProperty().bind(scene.heightProperty().divide(2));

        circle.radiusProperty().bind(Bindings.min(scene.widthProperty(),scene.heightProperty()).divide(2));


        stage.setScene(scene);
        stage.sizeToScene();

        stage.showAndWait();






    }



}
