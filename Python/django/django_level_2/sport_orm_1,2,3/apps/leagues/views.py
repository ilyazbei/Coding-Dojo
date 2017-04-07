from django.shortcuts import render, redirect
from .models import League, Team, Player

from . import team_maker
from django.db.models import Count

def index(request):
	context = {
		"all_leagues": League.objects.all(), #0
		"baseball_leagues": League.objects.filter(sport__contains="baseball"), #1
		"womens_leagues": League.objects.filter(name__contains="womens"), #2
		"hockey_leagues": League.objects.filter(sport__contains="hockey"), #3
		"notFottball_leagues": League.objects.all().exclude(sport__contains="football"), #4
		"conferences_leagues": League.objects.filter(name__contains="conference"), #5
		"atlantic_leagues": League.objects.filter(name__contains="atlantic"), #6

		"all_teams": Team.objects.all(),
		"dallas_teams": Team.objects.filter(location__contains="dallas"), #7
		"raptors_teams": Team.objects.filter(team_name__contains="raptors"), #8
		"city_teams": Team.objects.filter(location__contains="city"), #9
		"nameT_teams": Team.objects.filter(team_name__startswith="t"), #10
		"alphabetical_teams": Team.objects.all().order_by("location"), #11
		"reAlphabetical_teams": Team.objects.all().order_by("-team_name"), #12

		"all_players": Player.objects.all(),
		"lastCooper_players": Player.objects.filter(last_name__contains="cooper"), #13
		"firstJoshua_players": Player.objects.filter(first_name__contains="joshua"), #14
		"lastCooperXjashua_players": Player.objects.filter(last_name__contains="cooper").exclude(first_name__contains="joshua"), #15
		"firstAlexanderORwyatt_players": Player.objects.filter(first_name__contains="alexander")|Player.objects.all().filter(first_name__contains="wyatt"), #16

	}
	return render(request, "leagues/index.html", context)

def make_data(request):
	team_maker.gen_leagues(10)
	team_maker.gen_teams(50)
	team_maker.gen_players(200)

	return redirect("index")

def orm2(request):
	context = {
		"atlanticSocc_teams": Team.objects.filter(league__name__contains="atlantic soccer conference"), #1

		"bostonPenguins": Player.objects.filter(curr_team__team_name__contains="penguins", curr_team__location__contains="boston"), #2

		"interCollegBasConf": Player.objects.filter(curr_team__league__name__contains="international collegiate baseball conference"), #3

		"footLopez": Player.objects.filter(last_name__contains="lopez", curr_team__league__name__contains="amateur football"), #4

		"allFootball_players": Player.objects.filter(curr_team__league__name__contains="football"), #5

		"Sophia_teams": Team.objects.filter(curr_players__first_name__contains="sophia"), #6

		"Sophia_leagues": League.objects.filter(teams__curr_players__first_name__contains="sophia"), #7

		"FloresNotWashington": Player.objects.filter(last_name__contains="flores").exclude(curr_team__team_name__contains="roughriders") #8
	}
	return render(request, "leagues/ORM_II.html", context)

def orm3(request):
	context = {
		"Samuel_Teams": Team.objects.filter(all_players__first_name__contains="Samuel", all_players__last_name__contains="Evans"), #1
		"players_Manitoba": Player.objects.filter(all_teams__team_name__contains="tiger-cats", all_teams__location__contains="manitoba"), #2
		"playersFormerly": Player.objects.filter(all_teams__location__contains="wichita").exclude(curr_team__location__contains="wichita"), #3
		"jacob_beforeColts": Team.objects.filter(all_players__first_name__contains="jacob", all_players__last_name__contains="gray").exclude(curr_players__first_name__contains="jacob", curr_players__last_name__contains="gray"), #4
		"QUESTION_5": Player.objects.filter(first_name__contains="joshua", all_teams__league__name__contains="federation"), #5
		"QUESTION_6": Team.objects.annotate(num_players=Count('all_players')).filter(num_players__gt=12).order_by('num_players'), #6

		"QUESTION_7": Player.objects.annotate(num_players=Count('all_teams')).order_by('-num_players') #7




	}
	return render(request, "leagues/ORM_III.html", context)
