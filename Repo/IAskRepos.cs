using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programowanie_Projekt.Model;

namespace Programowanie_Projekt.Repo
{
    interface IAskRepos
    {   
        bool IsAskNull(Ask ask);
        bool AddAsk(Ask ask);

        bool DeleteAsk(int id);

        bool UpdateAsk(Ask ask);

        Ask[] Questions(int NumberOfQuestions);

        bool addScore(int score, int numberOfQuestions, string name);

        string[] ShowScores();

        List<Ask> ShowQuestions();

        Ask GetAsk(int id);

     


    }
}
