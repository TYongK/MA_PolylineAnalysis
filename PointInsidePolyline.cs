// FThis Code came from the website below.
// https://www.geeksforgeeks.org/how-to-check-if-a-given-point-lies-inside-a-polygon/

// Function to check if a point is inside a polygon
  static bool PointInPolygon(Point3d point, List<Point3d> polygon)
  {
    int numVertices = polygon.Count;
    double x = point.X;
    double y = point.Y;
    bool inside = false;

    // Store the first point in the polygon and initialize the second point
    Point3d p1 = polygon[0];
    Point3d p2 = Point3d.Unset;

    // Loop through each edge in the polygon
    for (int i = 1; i <= numVertices; i++)
    {
      // Get the next point in the polygon
      p2 = polygon[i % numVertices];

      // Check if the point is above the minimum y coordinate of the edge
      if (y > Math.Min(p1.Y, p2.Y))
      {
        // Check if the point is below the maximum y coordinate of the edge
        if (y <= Math.Max(p1.Y, p2.Y))
        {
          // Check if the point is to the left of the maximum x coordinate of the edge
          if (x <= Math.Max(p1.X, p2.X))
          {
            // Calculate the x-intersection of the line connecting the point to the edge
            double xIntersection = (y - p1.Y) * (p2.X - p1.X) / (p2.Y - p1.Y) + p1.X;

            // Check if the point is on the same line as the edge or to the left of the x-intersection
            if (p1.X == p2.X || x <= xIntersection)
            {
              // Flip the inside flag
              inside = !inside;
            }
          }
        }
      }

      // Store the current point as the first point for the next iteration
      p1 = p2;
    }

    // Return the value of the inside flag
    return inside;
  }
