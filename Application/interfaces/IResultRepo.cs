﻿using Application.Models;

namespace Application.interfaces
{
  public interface IResultRepo:IGenericRepo<Result>
    {
        IEnumerable<Result> GetResultWithStudentsAndCourses();
       
    }
}
