// import { Branch } from './branch.model'; // Adjust the path as needed


export interface Branch {
  lat: number;
  lng: number;
  name: string;
  // ...other properties...
}

export interface BranchMapMarker {
  label: string;
  position: { lat: number; lng: number };
  title: string;
  options: any;
  branch: Branch;
}
