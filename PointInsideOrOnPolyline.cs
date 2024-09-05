static bool PointInOrOnPolygon(Point3d point, List<Point3d> polygon)
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
                        if (p2.X == p1.X || x <= xIntersection)
                        //if (p2.X - 0.00001 < p1.X && p1.X < p2.X + 0.00001)
                        {
                            // Flip the inside flag
                            inside = !inside;
                        }
                    }
                }
            }

            // Point on Line Segment
            double AB = Math.Sqrt((p2.X-p1.X)*(p2.X-p1.X)+(p2.Y-p1.Y)*(p2.Y-p1.Y));
            double AP = Math.Sqrt((x-p1.X)*(x-p1.X)+(y-p1.Y)*(y-p1.Y));
            double PB = Math.Sqrt((p2.X-x)*(p2.X-x)+(p2.Y-y)*(p2.Y-y));
            if( AP + PB - 0.00001 < AB && AB < AP + PB + 0.00001)
                return true;

            // Store the current point as the first point for the next iteration
            p1 = p2;
        }

        // Return the value of the inside flag
        return inside;
    }
