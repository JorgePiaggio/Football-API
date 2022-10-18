import { Team } from "./team";

export class Season {
  id: number;
  startDate: Date;
  endDate: Date;
  currentMatchDay: number;
  winner: Team;
}
