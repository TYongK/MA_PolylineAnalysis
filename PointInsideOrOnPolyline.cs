public bool IsPointInOrOnPolygon(Point3d[] polygon, Point3d testPoint, double tolerance)
  {
      bool result = false;
      int j = polygon.Count() - 1;
      for (int i = 0; i < polygon.Count(); i++)
      {
      if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
      {
          if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
          {
          result = !result;
          }
      }

      if(IsInsideLineStrict(new Line(polygon[i], polygon[j]), testPoint.X, testPoint.Y, tolerance))
      {
          return true;
      }
      j = i;
      }

      Array.Clear(polygon, 0, polygon.Length);
      return result;
  }
   // Returns true if given point(x,y) is inside or ends of the given line segment
  private bool IsInsideLineStrict(Line line, double x, double y, double tol)
  {
      return (x >= line.From.X - tol && x <= line.To.X + tol
      || x >= line.To.X - tol && x <= line.From.X + tol)
      && (y >= line.From.Y - tol && y <= line.To.Y + tol
      || y >= line.To.Y - tol && y <= line.From.Y + tol);
  }

  private bool CheckIfDifferent(Point3d pA, Point3d pB, double tol)
  {
      if(tol > Math.Abs(pA.X - pB.X)
      && tol > Math.Abs(pA.Y - pB.Y)
      && tol > Math.Abs(pA.Z - pB.Z))
      {
      return false;
      }
      else
      {
      return true;
      }
  }
