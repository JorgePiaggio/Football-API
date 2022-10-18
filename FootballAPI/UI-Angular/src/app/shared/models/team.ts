import { Area } from "./area";
import { Competition } from "./competition";
import { Player } from "./player";

export class Team{
  id: number;
  area: Area;
  name: string;
  shortName: string;
  tla: string;
  crest: string;
  address: string;
  website: string;
  founded: number;
  clubColours: string;
  venue: number;
  runningCompetitions: Competition[];
  marketValue: number;
  squad: Player[];
  numberOfAvailableSeasons: number;
}
