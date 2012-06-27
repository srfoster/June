package june;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class Wand
{
	String color;
	long last_datetime;

	public Wand(String color)
	{
		this.color = color;
	}

	public Direction getGesture()
	{
		String gesture = getGestureString();

		if(gesture.equals("Right"))
			return Direction.right();

		if(gesture.equals("Left"))
			return Direction.left();

		return Direction.none();
	}

	private String getGestureString()
	{
            File f = new File(color + "_gesture.txt");
            long datetime = f.lastModified();

	    if(datetime == last_datetime)
	    {
		return "";
	    }

            last_datetime = datetime;

	    return readFromFile(f);
	}

	private String readFromFile(File file)
	{
		return new Scanner(file).useDelimiter("\\Z").next();
	}
}
