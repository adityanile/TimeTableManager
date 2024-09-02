import { SubjectData } from "@/app/types";
import { NextResponse } from "next/server";
import prisma from "@/lib/prisma";
import { Prisma } from "@prisma/client";

export async function POST(request: Request) {
  const subject: SubjectData = await request.json();

  if (!subject)
    return NextResponse.json({ status: "Fail", msg: "Invalid Params" });

  let res;

  try {
    res = await prisma.subjects.create({
      data: {
        name: subject.name,
        length: subject.length,
        startTime: subject.startTime,
        division: subject.division,
        branch: subject.branch,
        teachername: subject.teacherName,
        classroom: subject.classroom,
        dayofweek: subject.dayofWeek,
      },
    });
  } catch (e) {
    if (e instanceof Prisma.PrismaClientKnownRequestError) {
      return NextResponse.json({ status: "fail", e });
    }
  }
  return NextResponse.json({ status: "success", subjectID: res?.id });
}
