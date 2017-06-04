import java.util.Arrays;
import java.util.ArrayList;

public class BruteCollinearPoints {
    private ArrayList<LineSegment> segments;

    /**
     * Finds all line segments containing 4 points.
     */
    public BruteCollinearPoints(Point[] points) {
        /* make sure there are no duplicates */
        for (int i = 0; i < points.length; i++) {
            for (int j = i + 1; j < points.length; j++) {
                if (points[i].compareTo(points[j]) == 0)
                    throw new java.lang.IllegalArgumentException();
            }
        }

        segments = new ArrayList<LineSegment>();
        findSegments(points);
    }
    
    private void findSegments(Point[] pts) {
        Point[] points = Arrays.copyOf(pts, pts.length);
        Arrays.sort(points);
        
        for (int p = 0; p < points.length - 3; p++) {
            for (int q = p + 1; q < points.length - 2; q++) {
                for (int r = q + 1; r < points.length - 1; r++) {
                    for (int s = r + 1; s < points.length; s++) {
                        Point pP = points[p], pQ = points[q], pR = points[r], pS = points[s];

                        if (pP.slopeTo(pQ) == pP.slopeTo(pR) && pP.slopeTo(pQ) == pP.slopeTo(pS))
                            segments.add(new LineSegment(pP, pS));
                    }
                }
            }
        }
    }

    /**
     * The number of line segments.
     * @return the number of line segments
     */
    public int numberOfSegments() {
        return segments.size();
    }

    /**
     * The line segments.
     * @return the line segments
     */
    public LineSegment[] segments() {
        return segments.toArray(new LineSegment[segments.size()]);
    }
}