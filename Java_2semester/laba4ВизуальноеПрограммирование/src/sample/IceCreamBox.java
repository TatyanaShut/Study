package sample;

import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.paint.Color;
import javafx.scene.shape.*;
import javafx.stage.Modality;
import javafx.stage.Stage;

public class IceCreamBox {


    public static void display() {

        Stage stage = new Stage();
        stage.initModality(Modality.APPLICATION_MODAL);
        stage.setTitle("Рисуем мороженное ");


        Group root = new Group();

        Scene scene = new Scene(root, 306,550, Color.WHITE);

        Path path = new Path();
        path.setStrokeWidth(3);

        MoveTo moveTo = new MoveTo();

        moveTo.setX(50);
        moveTo.setY(150);

        QuadCurveTo quadCurveTo = new QuadCurveTo();
        quadCurveTo.setX(150);
        quadCurveTo.setY(150);
        quadCurveTo.setControlX(100);
        quadCurveTo.setControlY(50);

        LineTo lineTo1 = new LineTo();

        lineTo1.setX(50);
        lineTo1.setY(150);


        LineTo lineTo2 = new LineTo();
        lineTo2.setX(100);
        lineTo2.setY(275);


        LineTo lineTo3 = new LineTo();
        lineTo3.setX(150);
        lineTo3.setY(150);

        Button colorRed = new Button ("Color");
        colorRed.setOnAction(e -> ColorIceCream.display());




        path.setFill(Color.YELLOW);

        path.getElements().addAll(moveTo,quadCurveTo,lineTo1,lineTo2,lineTo3);

        path.setTranslateY(30);
        root.getChildren().add(path);

        root.getChildren().add(colorRed);



        stage.setScene(scene);
        stage.showAndWait();



    }
}
