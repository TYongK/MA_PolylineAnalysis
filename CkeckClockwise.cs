  private bool IsClockwisePolygon(List<Point3d> polygon)
  {
    bool isClockwise = false;
    double sum = 0;
    for ( int i = 0; i < polygon.Count - 1; i++)
    {
      sum += (polygon[i + 1].X - polygon[i].X) * (polygon[i + 1].Y + polygon[i].Y);
    }
    isClockwise = (sum > 0) ? true : false;
    return isClockwise;
  }
