import java.util.Arrays;
import java.util.ArrayList;
import java.util.HashMap;

public class FastCollinearPoints {
    private ArrayList<LineSegment> segments;
    
    /* Holds the existing end points for each slope */
    private HashMap<Double, ArrayList<Point>> segmentEndpoints = new HashMap<Double, ArrayList<Point>>();

    /**
     * Finds all line segments containing 4 points.
     * @param points the points to consider
     */
    public FastCollinearPoints(Point[] points) {
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

    /**
     * Finds all line segments containing 4 or more points.
     * @param points the points to consider
     */
    private void findSegments(Point[] pts) {
        Point[] points = Arrays.copyOf(pts, pts.length);
        Arrays.sort(points);

        for (Point start : pts) {
            Arrays.sort(points, start.slopeOrder());

            double newSlope = 0;
            double slope = Double.NEGATIVE_INFINITY;

            Point max = start;
            Point min = start;
            int len = 1;

            for (int i = 1; i < points.length; i++) {
                Point end = points[i];
                newSlope = start.slopeTo(end);

                if (newSlope == slope) {
                    if (max.compareTo(end) < 0)
                        max = end;
                    else if (min.compareTo(end) > 0)
                        min = end;
                    len++;
                } else {
                    if (len > 3) {
                        //segments.add(new LineSegment(min, max));
                        recordSegment(min, max, slope);
                    }

                    /* new slope, new segment */
                    slope = newSlope;

                    /* set a new min and max */
                    if (start.compareTo(end) < 0) {
                        max = end;
                        min = start;
                    } else {
                        max = start;
                        min = end;
                    }
                    len = 2;
                }
            }

            if (len > 3) {
                //segments.add(new LineSegment(min, max));
                recordSegment(min, max, slope);
            }
        }
    }

    /**
     * Records a segment as part of the result, if not already recorded.
     * @param segment the segment being considered
     * @param slope the slope of the segment (saves some calculations)
     */
    private void recordSegment(Point start, Point end, double slope) {
        /* get endpoints for this slope */
        ArrayList<Point> endPoints = segmentEndpoints.get(slope);

        /* if no entry */
        if (endPoints == null) {
            endPoints = new ArrayList<Point>();
            endPoints.add(end);

            segmentEndpoints.put(slope, endPoints);
            /* this is a valid endpoint, so we have a new line segment */
            segments.add(new LineSegment(start, end));
        } else {
            /* if we have this end point already recorded, we are done */
            for (Point ep : endPoints) {
                if (ep.compareTo(end) == 0) {
                    return;
                }
            }

            /* record this end point and make a new segment */
            endPoints.add(end);
            segments.add(new LineSegment(start, end));
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