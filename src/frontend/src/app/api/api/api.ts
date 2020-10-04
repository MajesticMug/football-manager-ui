export * from './competition.service';
import { CompetitionService } from './competition.service';
export * from './dataImports.service';
import { DataImportsService } from './dataImports.service';
export * from './players.service';
import { PlayersService } from './players.service';
export * from './teams.service';
import { TeamsService } from './teams.service';
export const APIS = [CompetitionService, DataImportsService, PlayersService, TeamsService];
