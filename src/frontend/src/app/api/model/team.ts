/**
 * Football API
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */
import { Player } from './player';
import { CompetitionTeam } from './competitionTeam';


export interface Team { 
    id?: number;
    code?: string | null;
    name?: string | null;
    shortName?: string | null;
    tla?: string | null;
    email?: string | null;
    areaName?: string | null;
    competitionTeams?: Array<CompetitionTeam> | null;
    players?: Array<Player> | null;
}

