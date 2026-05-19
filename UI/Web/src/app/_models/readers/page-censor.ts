export interface FreehandPoint {
  xPct: number;
  yPct: number;
}

export interface CensorRegion {
  xPct: number;
  yPct: number;
  wPct: number;
  hPct: number;
  style: 'blur' | 'black';
  blur: number;
  shape: 'rect' | 'ellipse' | 'freehand';
  points?: FreehandPoint[];
}

export interface PageCensor {
  id: number;
  chapterId: number;
  pageIndex: number;
  regions: CensorRegion[];
}
